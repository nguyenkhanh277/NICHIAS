using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class Customer : Base
    {
        #region Fields
        public string Id { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
