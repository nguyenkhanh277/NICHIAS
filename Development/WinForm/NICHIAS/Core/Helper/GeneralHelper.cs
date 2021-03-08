using DevExpress.Export;
using DevExpress.Export.Xl;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NICHIAS.Core.Helper
{
    public class GeneralHelper
    {
        //public static int Column = 0;
        //public static string Title = "";
        //public static string SoChungTu = "";
        //public static string KemHoaDonSo = "";
        //public static string KhachHang = "";
        //public static string DiaChiKH = "";
        //public static string MSTKH = "";
        //public static string Ngay = "";
        public static bool IsNumericType(Type type)
        {
            HashSet<Type> NumericTypes = new HashSet<Type>
            {
                typeof(decimal), typeof(byte), typeof(sbyte),
                typeof(short), typeof(ushort), typeof(float)
            };
            return NumericTypes.Contains(type) || NumericTypes.Contains(Nullable.GetUnderlyingType(type));
        }

        public static bool IsStringDouble(string stringNumber)
        {
            double number;
            return double.TryParse(stringNumber, out number);
        }

        public static bool ValidPrinter(string printerName)
        {
            bool result = false;
            try
            {
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    if (printerName == prtName)
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch { }
            return result;
        }

        public static bool ValidPortCOM(string portCOM)
        {
            bool result = false;
            try
            {
                foreach (string portName in SerialPort.GetPortNames())
                {
                    if (portCOM == portName)
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch { }
            return result;
        }

        public static void ExportExcel(GridControl gridControl)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel|*.xls;*.xlsx";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    gridControl.ExportToXlsx(fileName);
                    try
                    {
                        Process.Start(fileName);
                    }
                    catch { }
                }
            }
            catch { }

        }

        public static void ExportExcel(GridControl gridControl, XlsxExportOptionsEx options)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel|*.xls;*.xlsx";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExportSettings.DefaultExportType = ExportType.DataAware;
                    options.CustomizeCell += options_CustomizeCell;
                    //options.AfterAddRow += options_AfterAddRow;
                    options.SheetName = "Sheet1";
                    string fileName = saveFileDialog1.FileName;
                    gridControl.ExportToXlsx(fileName, options);
                    try
                    {
                        Process.Start(fileName);
                    }
                    catch { }
                }
            }
            catch { }

        }

        #region #AfterAddRowEvent
        //static void options_AfterAddRow(AfterAddRowEventArgs e)
        //{
        //    // Merge cells in rows that correspond to the grid's group rows.
        //    if (e.DataSourceRowIndex < 0)
        //    {
        //        e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(0, e.DocumentRow - 1), new XlCellPosition(5, e.DocumentRow - 1)));
        //    }
        //}
        #endregion #AfterAddRowEvent

        #region #CustomizeCellEvent
        // Specify the value alignment for Discontinued field.
        static XlCellAlignment aligmentForDiscontinuedColumn = new XlCellAlignment()
        {
            HorizontalAlignment = XlHorizontalAlignment.Center,
            VerticalAlignment = XlVerticalAlignment.Center
        };

        static void options_CustomizeCell(CustomizeCellEventArgs e)
        {
            // Substitute Boolean values within the Discontinued column by special symbols.
            if (e.ColumnFieldName == "Discontinued")
            {
                if (e.Value is bool)
                {
                    e.Handled = true;
                    e.Formatting.Alignment = aligmentForDiscontinuedColumn;
                    e.Value = ((bool)e.Value) ? "☑" : "☐";
                }
            }
        }
        #endregion #CustomizeCellEvent

    }
}