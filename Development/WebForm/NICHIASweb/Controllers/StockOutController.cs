using NICHIASweb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICHIASweb.Controllers
{
    public class StockOutController : Controller
    {
        ConnectionManagement _connectionManagement = new ConnectionManagement();
        DbBusiness _dbBusiness = new DbBusiness();
        enum CompletedStatusValue { None, OK, NG }
        enum StatusValue { NoUse, Using }
        string _username = "";
        string _barcode = "";
        string _partNumber = "Not Found PartNumber";

        string _result = "NG";
        string _description = "";

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Stock_Out")]
        public ActionResult Stock_Out(string barcode)
        {
            try
            {
                _barcode = barcode;
                if (VerifyProduct())
                {
                    if (VerifyScanBarcode())
                    {
                        if (VerifyStockOutExits())
                        {
                            if (WriteData())
                            {
                                _result = "OK";
                            }
                        }
                    }
                }
            }
            catch
            {
                _result = "NG";
                _description = "";
            }
            return Content(_result + "#" + _description);
        }

        private bool VerifyProduct()
        {
            bool result = false;
            DataTable product = _dbBusiness.GetProduct(_barcode, _connectionManagement.GetDefaultConnection());
            if (product.Rows.Count == 0)
                _description += "KHÔNG TÌM THẤY SẢN PHẨM " + _barcode + Environment.NewLine;
            else
            {
                _partNumber = product.Rows[0]["PartNumber"].ToString();
                result = true;
            }
            return result;
        }

        private bool VerifyScanBarcode()
        {
            bool result = false;
            DataTable scanBarcode = _dbBusiness.GetScanBarcode(_barcode, "", _connectionManagement.GetDefaultConnection());
            if (scanBarcode.Rows.Count == 0)
                _description += "SẢN PHẨM " + _barcode + " CHƯA ĐƯỢC SẤY " + Environment.NewLine;
            else
            {
                if (int.Parse(scanBarcode.Rows[0]["CompletedStatus"].ToString()) != (int)CompletedStatusValue.OK)
                {
                    _description += "SẢN PHẨM " + _barcode + " CHƯA HOÀN THÀNH" + Environment.NewLine;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        private bool VerifyStockOutExits()
        {
            bool result = false;
            DataTable stockOut = _dbBusiness.GetStockOut(_barcode, _connectionManagement.GetDefaultConnection());
            if (stockOut.Rows.Count > 0)
                _description += "SẢN PHẨM " + _barcode + " ĐÃ ĐƯỢC XUẤT HÀNG" + Environment.NewLine;
            else
            {
                result = true;
            }
            return result;
        }

        private bool WriteData()
        {
            bool result = false;
            if (_dbBusiness.StockOut(_barcode, _partNumber, (int)StatusValue.Using, _username, _connectionManagement.GetDefaultConnection()))
                result = true;
            else
                _description += "Xuất hàng thất bại do không kết nối được máy chủ" + Environment.NewLine;
            return result;
        }
    }
}