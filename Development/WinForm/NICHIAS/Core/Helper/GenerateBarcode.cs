using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Web;
using System.Windows.Forms;

namespace NICHIAS.Core.Helper
{
    public static class GenerateBarcode
    {
        public static string Barcode { get; set; }
        public static string PartNo { get; set; }
        public static string DateShift { get; set; }
        public static string MoldNoSEQ { get; set; }
        public static string VN { get; set; }
    }
}