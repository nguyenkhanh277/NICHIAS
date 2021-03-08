using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public string id = "";

        public CustomerRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(Customer customer)
        {
            if (String.IsNullOrEmpty(customer.Id))
            {
                customer.Id = GetAutoID();
                customer.CreatedAt = DateTime.Now;
                customer.CreatedBy = GlobalConstants.username;
                Add(customer);
                id = customer.Id;
            }
            else
            {
                Update(customer);
            }
        }

        public void Update(Customer customer)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(customer.Id));
                if (raw != null)
                {
                    raw.CollectInformation(customer);
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