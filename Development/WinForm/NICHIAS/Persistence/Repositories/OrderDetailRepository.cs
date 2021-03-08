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
    public class OrderDetailRepository : Repository<OrderDetail>
    {
        public string id = "";

        public OrderDetailRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(OrderDetail orderDetail)
        {
            if (String.IsNullOrEmpty(orderDetail.Id))
            {
                orderDetail.Id = GetAutoID();
                orderDetail.CreatedAt = DateTime.Now;
                orderDetail.CreatedBy = GlobalConstants.username;
                Add(orderDetail);
                id = orderDetail.Id;
            }
            else
            {
                Update(orderDetail);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(orderDetail.Id));
                if (raw != null)
                {
                    raw.CollectInformation(orderDetail);
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