using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class Production : Base
    {
        #region Fields
        public string Id { get; set; }
        public string ScheduleLotId { get; set; }
        public string ProductProcessId { get; set; }//Tại máy quấn -> Min ProcessNo thì in phiếu công đoạn
        public string ProductType { get; set; }//Inner / Outers
        //ScheduleLotId + I hoặc O + SEQ (00)
        public string Barcode { get; set; }
        public DateTime ScanIn { get; set; }
        public DateTime? Limit { get; set; }
        public DateTime? ScanOut { get; set; }
        public float ActualProductionTime { get; set; }
        public GlobalConstants.ResultStatusValue ResultStatus { get; set; }
        public GlobalConstants.CompletedStatusValue CompletedStatus { get; set; }
        #endregion
    }
}
