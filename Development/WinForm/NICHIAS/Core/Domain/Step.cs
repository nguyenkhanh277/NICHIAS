using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class Step : Base
    {
        #region Fields
        public string Id { get; set; }
        public int StepNo { get; set; }
        public string StepName { get; set; }
        public GlobalConstants.RequestScanValue RequestScanIn { get; set; }
        public GlobalConstants.RequestScanValue RequestScanOut { get; set; }
        public string Note { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
