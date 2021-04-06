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
    public class PurchaseOrderRepository : Repository<PurchaseOrder>
    {
        public string id = "";

        public PurchaseOrderRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(PurchaseOrder purchaseOrder)
        {
            if (String.IsNullOrEmpty(purchaseOrder.Id))
            {
                purchaseOrder.Id = GetAutoID();
                purchaseOrder.CreatedAt = DateTime.Now;
                purchaseOrder.CreatedBy = GlobalConstants.username;
                Add(purchaseOrder);
                id = purchaseOrder.Id;
            }
            else
            {
                Update(purchaseOrder);
            }
        }

        public void Update(PurchaseOrder purchaseOrder)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(purchaseOrder.Id));
                if (raw != null)
                {
                    raw.CollectInformation(purchaseOrder);
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