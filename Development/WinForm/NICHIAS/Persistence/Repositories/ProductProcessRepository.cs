using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class ProductProcessRepository : Repository<ProductProcess>
    {
        public string id = "";

        public ProductProcessRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(ProductProcess productProcess)
        {
            if (String.IsNullOrEmpty(productProcess.Id))
            {
                productProcess.Id = GetAutoID();
                productProcess.CreatedAt = DateTime.Now;
                productProcess.CreatedBy = GlobalConstants.username;
                Add(productProcess);
                id = productProcess.Id;
            }
            else
            {
                Update(productProcess);
            }
        }

        public void Update(ProductProcess productProcess)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(productProcess.Id));
                if (raw != null)
                {
                    raw.CollectInformation(productProcess);
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