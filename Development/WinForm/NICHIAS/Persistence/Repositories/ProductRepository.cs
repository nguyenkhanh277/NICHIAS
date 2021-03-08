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
    public class ProductRepository : Repository<Product>
    {
        public string id = "";

        public ProductRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(Product product)
        {
            if (String.IsNullOrEmpty(product.Id))
            {
                product.Id = GetAutoID();
                product.CreatedAt = DateTime.Now;
                product.CreatedBy = GlobalConstants.username;
                Add(product);
                id = product.Id;
            }
            else
            {
                Update(product);
            }
        }

        public void Update(Product product)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(product.Id));
                if (raw != null)
                {
                    raw.CollectInformation(product);
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