using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class ScheduleLot : Base
    {
        #region Fields
        //V + Ngày tháng thực tế (yyMM) + SEQ
        public string Id { get; set; }
        public string OrderId { get; set; }
        //Key Product
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string MachineId { get; set; }//Chỉ hiển thị MachineType = 1 (Máy Quấn)
        public int SEQ { get; set; }//Theo tháng
        //LotNo = Mã nhà máy(1) + ScheduleDate (yyMMdd) + MachineNo + SEQ (0000)
        public string LotNo { get; set; }
        public GlobalConstants.ProductionStatusValue ProductionStatus { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
