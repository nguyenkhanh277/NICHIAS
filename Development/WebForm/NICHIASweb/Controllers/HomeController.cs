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

        [ActionName("Login")]
        public ActionResult Login(string username, string functionName)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement();
            DbBusiness dbBusiness = new DbBusiness();
            string result = "NG";
            string description = "";
            try
            {
                //if (!dbBusiness.ExistUser(username, connectionManagement.GetDefaultConnection()))
                //{
                //    result = "NG";
                //    description = "Tài khoản này không tồn tại";
                //}
                //else
                {
                    //if (!dbBusiness.CheckAuthorization(username, functionName, connectionManagement.GetDefaultConnection()))
                    //{
                    //    result = "NG";
                    //    description = "Tài khoản này không có quyền";
                    //}
                    //else
                    {
                        result = "OK";
                        description = "";
                    }
                }
            }
            catch
            {
                result = "NG";
                description = "Không thể kết nối với máy chủ";
            }
            return Content(result + "#" + description);
        }
    }
}