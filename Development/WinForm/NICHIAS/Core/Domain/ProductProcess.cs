using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class ProductProcess : Base
    {
        #region Fields
        public string Id { get; set; }
        public int ProcessNo { get; set; }
        public string PartNumber { get; set; }
        public int StepId { get; set; }
        [NotMapped]
        public string StepName { get; set; }
        public float ProductionTime { get; set; }
        #endregion
    }
}
