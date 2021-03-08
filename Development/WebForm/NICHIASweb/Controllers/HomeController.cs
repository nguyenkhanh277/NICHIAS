using NICHIASweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICHIASweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("CheckUser")]
        public ActionResult CheckUser(string username, string programName, string functionName)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement();
            DbBusiness dbBusiness = new DbBusiness();
            string result = "NG";
            string description = "";
            try
            {
                if (!dbBusiness.ExistOperator(username, connectionManagement.GetDefaultConnection()))
                {
                    result = "NG";
                    description = "Ma nguoi dung nay khong ton tai";
                }
                else
                {
                    //if (!dbBusiness.CheckAuthorization(username, programName, functionName, connectionManagement.GetDefaultConnection()))
                    //{
                    //    result = "NG";
                    //    description = "Ma nguoi dung nay khong co quyen";
                    //}
                    //else
                    //{
                    result = "OK";
                    description = "";
                    //}
                }
            }
            catch
            {
                result = "NG";
                description = "Khong the ket noi toi may chu";
            }
            return Content(result + "#" + description);
        }
    }
}