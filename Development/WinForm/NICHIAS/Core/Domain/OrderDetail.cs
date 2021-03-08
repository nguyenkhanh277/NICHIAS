using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class OrderDetail : Base
    {
        #region Fields
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string PartNumber { get; set; }
        public float OrderQuantity { get; set; }
        public float ActualQuantity { get; set; }
        #endregion
    }
}
