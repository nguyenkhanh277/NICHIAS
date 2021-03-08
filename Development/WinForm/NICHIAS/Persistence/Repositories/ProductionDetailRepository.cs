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
    public class ProductionDetailRepository : Repository<ProductionDetail>
    {
        public string id = "";

        public ProductionDetailRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(ProductionDetail productionDetail)
        {
            if (String.IsNullOrEmpty(productionDetail.Id))
            {
                productionDetail.Id = GetAutoID();
                productionDetail.CreatedAt = DateTime.Now;
                productionDetail.CreatedBy = GlobalConstants.username;
                Add(productionDetail);
                id = productionDetail.Id;
            }
            else
            {
                Update(productionDetail);
            }
        }

        public void Update(ProductionDetail productionDetail)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(productionDetail.Id));
                if (raw != null)
                {
                    raw.CollectInformation(productionDetail);
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