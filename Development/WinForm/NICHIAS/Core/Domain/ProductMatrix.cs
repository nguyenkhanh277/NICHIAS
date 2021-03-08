using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class ProductMatrix : Base
    {
        #region Fields
        public string Id { get; set; }
        public string PartNumber { get; set; }
        public string StepNo { get; set; }
        public float ProductionTime { get; set; }
        public string Shift { get; set; }
        #endregion
    }
}
