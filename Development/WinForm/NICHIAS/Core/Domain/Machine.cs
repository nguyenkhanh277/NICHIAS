using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class Machine : Base
    {
        #region Fields
        public string Id { get; set; }
        public int MachineNo { get; set; }
        public string MachineName { get; set; }
        public string Note { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
