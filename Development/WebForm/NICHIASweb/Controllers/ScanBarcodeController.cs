using NICHIASweb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICHIASweb.Controllers
{
    public class ScanBarcodeController : Controller
    {
        ConnectionManagement _connectionManagement = new ConnectionManagement();
        DbBusiness _dbBusiness = new DbBusiness();
        enum ResultStatusValue { Processing, OK, Timeless, Timeout }
        enum CompletedStatusValue { None, OK, NG }
        enum RequestScanValue { No, Yes }
        enum StatusValue { NoUse, Using }
        enum ControlSerialData { Error, Warning, Reset }
        string _reason = "";
        string _username = "";
        string _barcode = "";
        string _partNumber = "";
        string _placeNo = "";
        string _scanInOut = "";
        float _dungSai = 5;

        string _scanBarcodeIdCurrent = "";
        int _stepNoCurrent = 0;
        string _stepNameCurrent = "";
        float _dryingTimeCurrent = 0;
        DateTime _timeStartCurrent = new DateTime();
        DateTime _timeEndCurrent = new DateTime();
        TimeSpan _timeSpanCurrent = new TimeSpan();
        float _dryingTimeActualCurrent = 0;
        int _resultStatusActualCurrent = 0;

        string _scanBarcodeIdPrev = "";
        int _stepNoPrev = 0;
        float _dryingTimePrev = 0;
        DateTime _timeStartPrev = new DateTime();
        DateTime _timeEndPrev = new DateTime();
        TimeSpan _timeSpanPrev = new TimeSpan();
        float _dryingTimeActualPrev = 0;
        int _resultStatusActualPrev = 0;

        int _stepNoNext = 0;
        float _dryingTimeNext = 0;
        int _completedStatus = 0;

        string _result = "NG";
        string _description = "";
        string _continues = "";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult End(string placeNo, string barcode, string result, string message)
        {
            ViewBag.placeNo = placeNo;
            ViewBag.barcode = barcode;
            ViewBag.result = result;
            ViewBag.message = message;
            _dbBusiness.SendAlarm(_barcode, _partNumber, _stepNoCurrent, _description, (int)ControlSerialData.Reset, _username, _connectionManagement.GetDefaultConnection());
            return View();
        }

        public ActionResult Continue(string placeNo, string barcode, string result, string message)
        {
            ViewBag.placeNo = placeNo;
            ViewBag.barcode = barcode;
            ViewBag.result = result;
            ViewBag.message = message;
            _dbBusiness.SendAlarm(_barcode, _partNumber, _stepNoCurrent, _description, (int)ControlSerialData.Reset, _username, _connectionManagement.GetDefaultConnection());
            return View();
        }

        [ActionName("Send_Alarm")]
        public ActionResult Send_Alarm()
        {
            _dbBusiness.SendAlarm(_barcode, _partNumber, _stepNoCurrent, _description, (int)ControlSerialData.Reset, _username, _connectionManagement.GetDefaultConnection());
            return Content("");
        }

        [ActionName("Scan_Barcode")]
        public ActionResult Scan_Barcode(string placeNo, string barcode, string reason)
        {
            /*
            *****placeNo*****
            Vao-Nhà sấy
            Ra-Nhà sấy

            Vao-Máy khử tĩnh điện

            Ra-Khu vực chờ
            */

            try
            {
                _dungSai = _dbBusiness.GetDungSai(_connectionManagement.GetDefaultConnection());
                _placeNo = placeNo;
                _reason = reason;
                string[] place = _placeNo.Split('-');
                if (String.IsNullOrEmpty(placeNo) || place.Length != 2)
                {
                    _description += "KHÔNG TÌM THẤY VỊ TRÍ" + Environment.NewLine;
                    _partNumber = "Not Found Address";
                }
                else
                {
                    _scanInOut = place[0];
                    _stepNameCurrent = place[1];
                    _barcode = barcode;
                    if (VerifyProduct())
                    {
                        if (VerifyStep())
                        {
                            if (VerifyProductMatrixPrev())
                            {
                                if (VerifyTimePrev())
                                {
                                    if (VerifyProductMatrixCurrent())
                                    {
                                        if (VerifyTimeCurrent())
                                        {
                                            VerifyProductMatrixNext();
                                            if (WriteData())
                                            {
                                                _result = "OK";
                                                if (_scanInOut == "Vao")//Vị trí scan là đầu Vao
                                                {
                                                    MessageStepName("Vị trí tiếp theo là ", "Ra", _stepNoCurrent);
                                                }
                                                else//Vị trí scan là đầu ra
                                                {
                                                    MessageStepName("Vị trí tiếp theo là ", "Vao", _stepNoNext);
                                                }
                                            }
                                        }
                                    }
                                }
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
            if (_result == "NG")
            {
                if (!String.IsNullOrEmpty(_continues))
                    _dbBusiness.SendAlarm(_barcode, _partNumber, _stepNoCurrent, _description, (int)ControlSerialData.Warning, _username, _connectionManagement.GetDefaultConnection());
                else
                    _dbBusiness.SendAlarm(_barcode, _partNumber, _stepNoCurrent, _description, (int)ControlSerialData.Error, _username, _connectionManagement.GetDefaultConnection());
            }
            return Content(_result + "#" + _description + "#" + _continues);
        }

        private bool VerifyProduct()
        {
            bool result = false;
            DataTable product = _dbBusiness.GetProduct(_barcode, _connectionManagement.GetDefaultConnection());
            if (product.Rows.Count == 0)
            {
                _description += "KHÔNG TÌM THẤY SẢN PHẨM " + _barcode + Environment.NewLine;
                _partNumber = "Not Found PartNumber";
            }
            else
            {
                _partNumber = product.Rows[0]["PartNumber"].ToString();
                result = true;
            }
            return result;
        }

        private bool VerifyStep()
        {
            bool result = false;
            DataTable step = _dbBusiness.GetStepNo(_stepNameCurrent, _barcode, _connectionManagement.GetDefaultConnection());
            if (step.Rows.Count == 0)
            {
                _description += "KHÔNG TÌM THẤY BƯỚC SẤY " + _stepNameCurrent.ToUpper() + Environment.NewLine;
                _description += "hoặc sản phẩm " + _partNumber + Environment.NewLine + " đã được xử lý qua bước này" + Environment.NewLine;
            }
            else
            {
                _stepNoCurrent = int.Parse(step.Rows[0]["StepNo"].ToString());
                _stepNoPrev = _stepNoCurrent - 1;
                _stepNoNext = _stepNoCurrent + 1;
                result = true;
            }
            return result;
        }

        private void MessageStepNo(string message, DataTable dtb)
        {
            string inOut = "";
            int stepNo = 0;
            if (stepNo == 0)
            {
                if (dtb.Rows.Count > 0)
                {

                    if (dtb.Rows[0]["ScanOut"].ToString() != "")
                    {
                        inOut = "Vao";
                        stepNo = int.Parse(dtb.Rows[0]["StepNo"].ToString()) + 1;
                    }
                    else if (dtb.Rows[0]["ScanOut"].ToString() == "")
                    {
                        inOut = "Ra";
                        stepNo = int.Parse(dtb.Rows[0]["StepNo"].ToString());
                    }
                    else
                    {
                        inOut = "Vao";
                        stepNo = int.Parse(dtb.Rows[0]["StepNo"].ToString());
                    }
                }
                else
                {
                    inOut = "Vao";
                    stepNo = 1;
                }
            }
            if (stepNo > 0)
            {
                MessageStepName(message, inOut, stepNo);
            }
        }

        private void MessageStepName(string message, string inOut, int stepNo)
        {
            DataTable step = _dbBusiness.GetStepName(stepNo, _connectionManagement.GetDefaultConnection());
            string stepName = "";
            if (step.Rows.Count > 0)
            {
                stepName = step.Rows[0][0].ToString();
            }
            if (!String.IsNullOrEmpty(stepName))
            {
                _description += message + inOut + "-" + stepName + Environment.NewLine;
            }
        }

        private bool VerifyProductMatrixPrev()
        {
            bool result = true;
            if (_stepNoPrev > 0)
            {
                DataTable productMatrixPrev = _dbBusiness.GetProductMatrix(_partNumber, _stepNoPrev.ToString(), _connectionManagement.GetDefaultConnection());
                //Bước trước không yêu cầu scan thì sẽ tự động kết thúc
                if (productMatrixPrev.Rows.Count > 0 && int.Parse(productMatrixPrev.Rows[0]["RequestScanOut"].ToString()) == (int)RequestScanValue.No)
                    _dryingTimePrev = float.Parse(productMatrixPrev.Rows[0]["DryingTime"].ToString()) * 60;
                else//Bước trước yêu cầu phải scan
                {
                    DataTable scanBarcodePrev = _dbBusiness.GetScanBarcode(_barcode, "", _connectionManagement.GetDefaultConnection());
                    if (scanBarcodePrev.Rows.Count > 0 && scanBarcodePrev.Rows[0]["StepNo"].ToString() == _stepNoCurrent.ToString())
                    { }
                    else
                    {
                        result = false;
                        _description += "KHÔNG ĐÚNG VỊ TRÍ" + Environment.NewLine;
                        MessageStepNo("Vị trí phải là ", scanBarcodePrev);
                    }
                }
            }
            return result;
        }

        private bool VerifyTimePrev()
        {
            bool result = true;
            if (_stepNoPrev > 0)
            {
                DataTable scanBarcodePrev = _dbBusiness.GetScanBarcode(_barcode, _stepNoPrev.ToString(), _connectionManagement.GetDefaultConnection());
                if (scanBarcodePrev.Rows.Count == 0)//Bước trước chưa được nhập
                {
                    result = false;
                    _description += "KHÔNG ĐÚNG VỊ TRÍ" + Environment.NewLine;
                    scanBarcodePrev = _dbBusiness.GetScanBarcode(_barcode, "", _connectionManagement.GetDefaultConnection());
                    MessageStepNo("Vị trí phải là ", scanBarcodePrev);
                }
                else if (scanBarcodePrev.Rows.Count > 0 && scanBarcodePrev.Rows[0]["ScanOut"].ToString() == "")//Bước trước chưa kết thúc
                {
                    //Tính thời gian sấy bước trước
                    _timeStartPrev = DateTime.Parse(scanBarcodePrev.Rows[0]["ScanIn"].ToString());
                    _timeEndPrev = DateTime.Now;
                    _timeSpanPrev = _timeEndPrev - _timeStartPrev;
                    _dryingTimeActualPrev = float.Parse(_timeSpanPrev.TotalMinutes.ToString("N0"));
                    _scanBarcodeIdPrev = scanBarcodePrev.Rows[0]["Id"].ToString();
                    //So sánh thời gian sấy thực tế > thời gian sấy yêu cầu + dung sai -> Quá thời gian
                    if (_dryingTimePrev > 0 && _dryingTimeActualPrev > _dryingTimePrev + _dungSai)
                    {
                        _continues = "continues";
                        _description += "Sản phẩm sấy QUÁ thời gian." + Environment.NewLine;
                        _description += "Số thời gian sấy thực tế: " + _dryingTimeActualPrev + "." + Environment.NewLine;
                        _description += "Số thời gian sấy yêu cầu: " + _dryingTimePrev + "." + Environment.NewLine;
                        _description += "Thời gian bắt đầu sấy: " + _timeStartPrev.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _description += "Thời gian kết thúc sấy: " + _timeEndPrev.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _resultStatusActualPrev = (int)ResultStatusValue.Timeout;
                        if (String.IsNullOrEmpty(_reason))
                            result = false;
                    }
                    else if (_dryingTimePrev > 0 && _dryingTimeActualPrev < _dryingTimePrev - _dungSai)//So sánh thời gian sấy thực tế < thời gian sấy yêu cầu - dung sai -> Thiếu thời gian
                    {
                        _continues = "continues";
                        _description += "Sản phẩm sấy THIẾU thời gian." + Environment.NewLine;
                        _description += "Số thời gian sấy thực tế: " + _dryingTimeActualPrev + "." + Environment.NewLine;
                        _description += "Số thời gian sấy yêu cầu: " + _dryingTimePrev + "." + Environment.NewLine;
                        _description += "Thời gian bắt đầu sấy: " + _timeStartPrev.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _description += "Thời gian kết thúc sấy: " + _timeEndPrev.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _resultStatusActualPrev = (int)ResultStatusValue.Timeless;
                        if (String.IsNullOrEmpty(_reason))
                            result = false;
                    }
                    else
                        _resultStatusActualPrev = (int)ResultStatusValue.OK;
                }
            }
            return result;
        }

        private bool VerifyProductMatrixCurrent()
        {
            bool result = true;
            DataTable productMatrix = _dbBusiness.GetProductMatrix(_partNumber, _stepNoCurrent.ToString(), _connectionManagement.GetDefaultConnection());
            //Không tìm thấy bước hiện tại
            if (productMatrix.Rows.Count == 0)
            {
                result = false;
                _description += "KHÔNG TÌM THẤY BƯỚC SẤY " + Environment.NewLine + "của sản phẩm " + _partNumber + Environment.NewLine;
            }
            else
                _dryingTimeCurrent = float.Parse(productMatrix.Rows[0]["DryingTime"].ToString()) * 60;
            return result;
        }

        private bool VerifyTimeCurrent()
        {
            bool result = false;
            DataTable scanBarcodeCurrent = _dbBusiness.GetScanBarcode(_barcode, _stepNoCurrent.ToString(), _connectionManagement.GetDefaultConnection());
            if (_scanInOut == "Vao")//Vị trí scan là đầu Vao
            {
                if (scanBarcodeCurrent.Rows.Count > 0 && scanBarcodeCurrent.Rows[0]["ScanIn"].ToString() != "")//Bước sấy đã được nhập rồi thì không cho scan lần 2
                {
                    _description += "KHÔNG ĐÚNG VỊ TRÍ" + Environment.NewLine;
                    MessageStepName("Vị trí phải là ", "Ra", _stepNoCurrent);
                }
                else
                    result = true;
            }
            else//Vị trí scan là đầu ra
            {
                if (scanBarcodeCurrent.Rows.Count == 0)//Bước sấy chưa được nhập
                {
                    _description += "KHÔNG ĐÚNG VỊ TRÍ" + Environment.NewLine;
                    MessageStepName("Vị trí phải là ", "Vao", _stepNoCurrent);
                }
                else if (scanBarcodeCurrent.Rows.Count > 0 && scanBarcodeCurrent.Rows[0]["ScanOut"].ToString() != "")//Bước sấy đã được kết thúc rồi thì không cho scan lần 2
                {
                    _description += "KHÔNG ĐÚNG VỊ TRÍ" + Environment.NewLine;
                    MessageStepName("Vị trí phải là ", "Vao", _stepNoNext);
                }
                else
                {
                    //Tính thời gian sấy bước trước
                    _timeStartCurrent = DateTime.Parse(scanBarcodeCurrent.Rows[0]["ScanIn"].ToString());
                    _timeEndCurrent = DateTime.Now;
                    _timeSpanCurrent = _timeEndCurrent - _timeStartCurrent;
                    _dryingTimeActualCurrent = float.Parse(_timeSpanCurrent.TotalMinutes.ToString("N0"));
                    _scanBarcodeIdCurrent = scanBarcodeCurrent.Rows[0]["Id"].ToString();
                    //So sánh thời gian sấy thực tế > thời gian sấy yêu cầu + dung sai -> Quá thời gian
                    if (_dryingTimeCurrent > 0 && _dryingTimeActualCurrent > _dryingTimeCurrent + _dungSai)
                    {
                        _continues = "continues";
                        _description += "Sản phẩm sấy QUÁ thời gian." + Environment.NewLine;
                        _description += "Số thời gian sấy thực tế: " + _dryingTimeActualCurrent + "." + Environment.NewLine;
                        _description += "Số thời gian sấy yêu cầu: " + _dryingTimeCurrent + "." + Environment.NewLine;
                        _description += "Thời gian bắt đầu sấy: " + _timeStartCurrent.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _description += "Thời gian kết thúc sấy: " + _timeEndCurrent.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _resultStatusActualCurrent = (int)ResultStatusValue.Timeout;
                        if (!String.IsNullOrEmpty(_reason))
                            result = true;
                    }
                    else if (_dryingTimeCurrent > 0 && _dryingTimeActualCurrent < _dryingTimeCurrent - _dungSai)//So sánh thời gian sấy thực tế < thời gian sấy yêu cầu - dung sai -> Thiếu thời gian
                    {
                        _continues = "continues";
                        _description += "Sản phẩm sấy THIẾU thời gian." + Environment.NewLine;
                        _description += "Số thời gian sấy thực tế: " + _dryingTimeActualCurrent + "." + Environment.NewLine;
                        _description += "Số thời gian sấy yêu cầu: " + _dryingTimeCurrent + "." + Environment.NewLine;
                        _description += "Thời gian bắt đầu sấy: " + _timeStartCurrent.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _description += "Thời gian kết thúc sấy: " + _timeEndCurrent.ToString("dd/MM/yy HH:mm") + "." + Environment.NewLine;
                        _resultStatusActualCurrent = (int)ResultStatusValue.Timeless;
                        if (!String.IsNullOrEmpty(_reason))
                            result = true;
                    }
                    else
                    {
                        _resultStatusActualCurrent = (int)ResultStatusValue.OK;
                        result = true;
                    }
                }
            }
            return result;
        }

        private void VerifyProductMatrixNext()
        {
            if (_stepNoNext > 0 && (String.IsNullOrEmpty(_reason) || (!String.IsNullOrEmpty(_reason) && !_reason.Contains("Ket thuc:"))))
            {
                DataTable productMatrixNext = _dbBusiness.GetProductMatrix(_partNumber, _stepNoNext.ToString(), _connectionManagement.GetDefaultConnection());
                //Không còn bước sau thì sẽ kết thúc
                if (productMatrixNext.Rows.Count == 0)
                {
                    _completedStatus = (int)CompletedStatusValue.OK;
                }
                //Bước sau không yêu cầu scan thì sẽ tự động nhập
                else if (productMatrixNext.Rows.Count > 0 && int.Parse(productMatrixNext.Rows[0]["RequestScanIn"].ToString()) == (int)RequestScanValue.No)
                {
                    //Lấy thời gian sấy bước sau
                    _dryingTimeNext = float.Parse(productMatrixNext.Rows[0]["DryingTime"].ToString()) * 60;
                    if (_dryingTimeNext == 0)
                        _completedStatus = (int)CompletedStatusValue.OK;
                }
            }
        }

        private bool WriteData()
        {
            bool result = false;
            //int completedStatus = (int)CompletedStatusValue.None;
            if (!String.IsNullOrEmpty(_reason) && _reason.Contains("Ket thuc:"))
                _completedStatus = (int)CompletedStatusValue.NG;
            if (_scanInOut == "Vao")//Vị trí scan là đầu Vao
            {
                if (_dbBusiness.ScanIn(_barcode, _partNumber, _stepNoCurrent, _dryingTimeCurrent, (int)ResultStatusValue.Processing, (int)CompletedStatusValue.None, (int)StatusValue.Using, _username, _scanBarcodeIdPrev, _timeEndPrev, _dryingTimeActualPrev, _resultStatusActualPrev, "Automatic", _connectionManagement.GetDefaultConnection()))
                    result = true;
                else
                    _description += "Xác nhận sản phẩm sấy thất bại do không kết nối được máy chủ" + Environment.NewLine;
            }
            else//Vị trí scan là đầu ra
            {
                if (!String.IsNullOrEmpty(_scanBarcodeIdCurrent) && _dbBusiness.ScanOut(_scanBarcodeIdCurrent, _timeEndCurrent, _dryingTimeActualCurrent, _resultStatusActualCurrent, _reason, _completedStatus, _username, _barcode, _partNumber, _stepNoNext, _dryingTimeNext, (int)ResultStatusValue.Processing, (int)CompletedStatusValue.None, (int)StatusValue.Using, _connectionManagement.GetDefaultConnection()))
                    result = true;
                else
                {
                    if (!String.IsNullOrEmpty(_reason) && _reason.Contains("Ket thuc:"))
                        _description += "Xác nhận kết thúc sản phẩm sấy thất bại do không kết nối được máy chủ" + Environment.NewLine;
                    else
                        _description += "Xác nhận sản phẩm sấy thất bại do không kết nối được máy chủ" + Environment.NewLine;
                }
            }
            return result;
        }
    }
}