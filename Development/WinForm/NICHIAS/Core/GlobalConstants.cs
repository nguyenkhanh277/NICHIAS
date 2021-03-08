using NICHIAS.Core.Domain;
using Registration.Core.License;
using System;
using System.Collections.Generic;
using System.Data;

namespace NICHIAS.Core
{
    public class GlobalConstants
    {
        #region Default Values
        public static string keySoft = "KSOFT";
        public static string saltSoft = "O12ab88cKh@nh";
        public static kLicense license;
        public static int language = 0;
        public static List<LanguageLibrary> languageLibrary = new List<LanguageLibrary>();
        public static int defaultSaltLength = 5;
        public static bool debugMode = true;
        public static string userId = "";
        public static string username = "";
        public static string fullName = "";
        public static string Company = "";
        public static string Address = "";
        public static string Phone = "";
        public static string TaxCode = "";
        public enum AuthorityGroupValue { Admin }
        public enum GenderValue { Female, Male }
        public enum StatusValue { NoUse, Using }
        public enum RequestScanValue { No, Yes }
        public enum ResultStatusValue { Processing, OK, Timeless, Timeout }
        public enum CompletedStatusValue { None, OK, NG }
        public enum ProductionStatusValue { NotYet, Proceeding, Completed, Cancel }
        public enum LanguageValue { Vietnamese, English }
        #endregion
    }
}
