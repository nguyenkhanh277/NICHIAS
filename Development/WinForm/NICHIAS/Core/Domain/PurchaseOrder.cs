using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class PurchaseOrder : Base
    {
        #region Fields
        public string Id { get; set; }
        public string PO { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public DateTime? EstimateProductionDate { get; set; }
        public string CustomerId { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
