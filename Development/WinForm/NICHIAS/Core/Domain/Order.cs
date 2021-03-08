using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class Order : Base
    {
        #region Fields
        public string Id { get; set; }
        public string PO { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string CustomerId { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
