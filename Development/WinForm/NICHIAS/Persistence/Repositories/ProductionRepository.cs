using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;
using System.Threading;
using System.Data;

namespace NICHIAS.Persistence.Repositories
{
    public class ProductionRepository : Repository<Production>
    {
        public string id = "";

        public ProductionRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(Production production)
        {
            if (String.IsNullOrEmpty(production.Id))
            {
                production.Id = GetAutoID();
                production.CreatedAt = DateTime.Now;
                production.CreatedBy = GlobalConstants.username;
                Add(production);
                id = production.Id;
            }
            else
            {
                Update(production);
            }
        }

        public void Update(Production production)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(production.Id));
                if (raw != null)
                {
                    raw.CollectInformation(production);
                    raw.EditedAt = DateTime.Now;
                    raw.EditedBy = GlobalConstants.username;
                    id = raw.Id;
                }
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.ToString();
            }
        }

        public string GetAutoID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}