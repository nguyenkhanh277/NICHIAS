using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class ProductionDetail : Base
    {
        #region Fields
        public string Id { get; set; }
        public string ProductionId { get; set; }
        public int StepNo { get; set; }
        public string StepName { get; set; }
        public DateTime ScanIn { get; set; }
        public DateTime? Limit { get; set; }
        public DateTime? ScanOut { get; set; }
        public float ProductionTime { get; set; }
        public GlobalConstants.ResultStatusValue ResultStatus { get; set; }
        public GlobalConstants.CompletedStatusValue CompletedStatus { get; set; }
        #endregion
    }
}
