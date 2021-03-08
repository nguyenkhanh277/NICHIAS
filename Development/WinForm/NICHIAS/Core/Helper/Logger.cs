using System;
using System.IO;
using System.Web;
using System.Windows.Forms;

namespace NICHIAS.Core.Helper
{
    public class Logger
    {
        public static void WriteStringLog(string sErrMsg)
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            if (GlobalConstants.debugMode)
            {
                System.Diagnostics.Debug.WriteLine(sLogFormat + sErrMsg);
            }
            else
            {
                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();
                string sErrorTime = sYear + sMonth + sDay + ".log";
                string file = Path.Combine(Application.StartupPath + "\\Logs", sErrorTime);
                StreamWriter sw = new StreamWriter(file, true);
                sw.WriteLine(sLogFormat + sErrMsg);
                sw.Flush();
                sw.Close();
            }
        }

        public static void ErrorLog(object input)
        {
            string outputString = ObjectToXml(input);
            WriteStringLog(outputString);
        }

        private static string ObjectToXml(object output)
        {
            string objectAsXmlString;

            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(output.GetType());
            using (StringWriter sw = new StringWriter())
            {
                try
                {
                    xs.Serialize(sw, output);
                    objectAsXmlString = sw.ToString();
                }
                catch (Exception ex)
                {
                    objectAsXmlString = ex.ToString();
                }
            }

            return objectAsXmlString;
        }
    }
}