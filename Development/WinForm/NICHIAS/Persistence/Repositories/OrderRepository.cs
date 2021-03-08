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
    public class OrderRepository : Repository<Order>
    {
        public string id = "";

        public OrderRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(Order order)
        {
            if (String.IsNullOrEmpty(order.Id))
            {
                order.Id = GetAutoID();
                order.CreatedAt = DateTime.Now;
                order.CreatedBy = GlobalConstants.username;
                Add(order);
                id = order.Id;
            }
            else
            {
                Update(order);
            }
        }

        public void Update(Order order)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(order.Id));
                if (raw != null)
                {
                    raw.CollectInformation(order);
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