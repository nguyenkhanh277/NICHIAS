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
    public class PurchaseOrderDetailRepository : Repository<PurchaseOrderDetail>
    {
        public string id = "";

        public PurchaseOrderDetailRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(PurchaseOrderDetail purchaseOrderDetail)
        {
            if (String.IsNullOrEmpty(purchaseOrderDetail.Id))
            {
                purchaseOrderDetail.Id = GetAutoID();
                purchaseOrderDetail.CreatedAt = DateTime.Now;
                purchaseOrderDetail.CreatedBy = GlobalConstants.username;
                Add(purchaseOrderDetail);
                id = purchaseOrderDetail.Id;
            }
            else
            {
                Update(purchaseOrderDetail);
            }
        }

        public void Update(PurchaseOrderDetail purchaseOrderDetail)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(purchaseOrderDetail.Id));
                if (raw != null)
                {
                    raw.CollectInformation(purchaseOrderDetail);
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