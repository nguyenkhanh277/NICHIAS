using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class Production : Base
    {
        #region Fields
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string LotNo { get; set; }
        public string MachineId { get; set; }
        public int SEQ { get; set; }
        public string PartNumber { get; set; }
        public string Size { get; set; }
        public float ProductLength { get; set; }
        public float ProductWidth { get; set; }
        public float ProductHeight { get; set; }
        public float ProductPCS { get; set; }
        public float RollLength { get; set; }
        public float RollWidth { get; set; }
        public float RollHeight { get; set; }
        public float RollPCS { get; set; }
        public float PaintType { get; set; }
        public float PCSPerLot { get; set; }
        public float PCSPerBatch { get; set; }
        public GlobalConstants.ProductionStatusValue ProductionStatus { get; set; }
        public string Reason { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
