using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class Machine : Base
    {
        #region Fields
        public string Id { get; set; }
        public string MachineType { get; set; }//1 = Máy cuốn | 2 = Máy mài thô | 3 = Máy nung | 4 = Máy ngâm | 5 = Máy mài | 6 = Máy sơn
        public string MachineNo { get; set; }
        public string MachineName { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
