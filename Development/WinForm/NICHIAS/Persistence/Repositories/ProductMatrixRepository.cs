using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class ProductMatrixRepository : Repository<ProductMatrix>
    {
        public string id = "";

        public ProductMatrixRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(ProductMatrix productMatrix)
        {
            if (String.IsNullOrEmpty(productMatrix.Id))
            {
                productMatrix.Id = GetAutoID();
                productMatrix.CreatedAt = DateTime.Now;
                productMatrix.CreatedBy = GlobalConstants.username;
                Add(productMatrix);
                id = productMatrix.Id;
            }
            else
            {
                Update(productMatrix);
            }
        }

        public void Update(ProductMatrix productMatrix)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(productMatrix.Id));
                if (raw != null)
                {
                    raw.CollectInformation(productMatrix);
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