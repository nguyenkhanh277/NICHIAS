using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NICHIAS.Core.Domain
{
    public class Product : Base
    {
        #region Fields
        public string Id { get; set; }
        public string PartNumber { get; set; }
        public string Revision { get; set; }//001 - 002 - 003 - ...
        public string PartName { get; set; }
        public string SizeO { get; set; }
        public float ColorType { get; set; }
        //Product
        public float ProductLength { get; set; }
        public float ProductWidth { get; set; }
        public float ProductHeight { get; set; }
        public float ProductPCS { get; set; }//32
        //Inner
        public float InnerRollLength { get; set; }
        public float InnerRollWidth { get; set; }
        public float InnerRollHeight { get; set; }
        public float InnerRollPCS { get; set; }//8
        public float InnerPCSPerBatch { get; set; }//2 + 2 + 2 + 2
        //Outer
        public float OuterRollLength { get; set; }
        public float OuterRollWidth { get; set; }
        public float OuterRollHeight { get; set; }
        public float OuterRollPCS { get; set; }//24
        public float OuterPCSPerBatch { get; set; }//12 + 12
        public string Note { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion
    }
}
