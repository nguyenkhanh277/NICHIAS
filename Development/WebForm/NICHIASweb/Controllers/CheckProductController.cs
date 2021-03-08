using NICHIASweb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICHIASweb.Controllers
{
    public class CheckProductController : Controller
    {
        string _result = "";

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Check_Product")]
        public ActionResult Check_Product(string barcode)
        {
            ConnectionManagement connectionManagement = new ConnectionManagement();
            DbBusiness dbBusiness = new DbBusiness();

            _result = "Testing";

            return Content(_result);
        }
    }
}