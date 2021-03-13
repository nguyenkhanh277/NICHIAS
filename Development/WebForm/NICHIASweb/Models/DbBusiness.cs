using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NICHIASweb.Models
{
    public class DbBusiness
    {
        #region User
        public bool ExistUser(string username, SqlConnection cn)
        {
            bool result = false;
            try
            {
                string query = @"SELECT Username, Password, Salt FROM Users WHERE Username = N'" + username + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    result = true;
            }
            catch (Exception ex) { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return result;
        }

        public bool CheckAuthorization(string username, string functionName, SqlConnection cn)
        {
            bool result = false;
            try
            {
                string query = @"SELECT UserAuthorities.UserId
                                FROM UserAuthorities
                                WHERE UserAuthorities.UserId = N'" + username + "' AND UserAuthorities.FunctionName = N'" + functionName + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    result = true;
            }
            catch (Exception ex) { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return result;
        }
        #endregion

        #region Production
        public float GetDungSai(SqlConnection cn)
        {
            float result = 5;
            DataTable tbl = new DataTable();
            try
            {
                string query = "SELECT DungSai FROM Settings";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
                result = (tbl.Rows.Count > 0 ? float.Parse(tbl.Rows[0][0].ToString()) : 5);
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return result;
        }

        public DataTable GetProduct(string barcode, SqlConnection cn)
        {
            DataTable tbl = new DataTable();
            try
            {
                string query = "SELECT PartNumber FROM RegistBarcodes WHERE Barcode = N'" + barcode + "'";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return tbl;
        }

        public DataTable GetStepNo(string stepName, string barcode, SqlConnection cn)
        {
            DataTable tbl = new DataTable();
            try
            {
                string dk = "";
                if (!String.IsNullOrEmpty(barcode))
                {
                    dk += " AND StepNo NOT IN (SELECT StepNo FROM Productions WHERE ScanOut IS NOT NULL AND Barcode = N'" + barcode + @"') ";
                }
                string query = "SELECT TOP 1 StepNo FROM Steps WHERE StepName = N'" + stepName + "' " + dk + " ORDER BY StepNo";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return tbl;
        }

        public DataTable GetStepName(int stepNo, SqlConnection cn)
        {
            DataTable tbl = new DataTable();
            try
            {
                string query = "SELECT TOP 1 StepName FROM Steps WHERE StepNo = N'" + stepNo + "' ";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return tbl;
        }

        public DataTable GetProductMatrix(string partNumber, string stepNo, SqlConnection cn)
        {
            DataTable tbl = new DataTable();
            try
            {
                string query = @"SELECT Steps.StepNo, Steps.RequestScanIn, Steps.RequestScanOut, ProductMatrices.DryingTime 
                                FROM Steps LEFT JOIN ProductMatrices ON Steps.StepNo = ProductMatrices.StepNo
                                WHERE ProductMatrices.PartNumber = N'" + partNumber + @"' AND Steps.StepNo = N'" + stepNo + @"'
                                ORDER BY Steps.StepNo";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return tbl;
        }

        public DataTable GetProduction(string barcode, string stepNo, SqlConnection cn)
        {
            DataTable tbl = new DataTable();
            try
            {
                string dk = (String.IsNullOrEmpty(stepNo) ? "" : " AND StepNo = '" + stepNo + @"' ");
                string query = @"SELECT Id, StepNo, ScanIn, ScanOut, CompletedStatus FROM Productions
                                WHERE Barcode = N'" + barcode + "'" + dk +
                                " ORDER BY StepNo DESC";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return tbl;
        }

        public DataTable GetStockOut(string barcode, SqlConnection cn)
        {
            DataTable tbl = new DataTable();
            try
            {
                string query = @"SELECT Id FROM StockOuts WHERE Barcode = N'" + barcode + "'";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                adp.Fill(tbl);
                adp.Dispose();
            }
            catch (Exception ex)
            { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return tbl;
        }

        public bool ScanIn(string barcode, string partNumber, int stepNoCurrent, float dryingTimeCurrent, int resultStatusCurrent, int completedStatus, int statusCurrent, string username, string idPrev, DateTime timeEndPrev, float dryingTimePrev, int resultStatusPrev, string reasonPrev, SqlConnection cn)
        {
            bool result = false;
            try
            {
                string query = "INSERT INTO Productions(Id, Barcode, PartNumber, StepNo, ScanIn, Limit, DryingTime, ResultStatus, CompletedStatus, Status, CreatedAt, CreatedBy) VALUES(N'" +
                    Guid.NewGuid().ToString() + "', N'" +
                    barcode + "', N'" +
                    partNumber + "', N'" +
                    stepNoCurrent + "', N'" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                    DateTime.Now.AddMinutes(dryingTimeCurrent).ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                    0 + "', N'" +
                    resultStatusCurrent + "', N'" +
                    completedStatus + "', N'" +
                    statusCurrent + "', N'" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                    username + "');";
                if (!String.IsNullOrEmpty(idPrev))
                {
                    query += "UPDATE Productions SET " +
                         "ScanOut = N'" + timeEndPrev.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                         "DryingTime = N'" + dryingTimePrev.ToString() + "'," +
                         "ResultStatus = N'" + resultStatusPrev + "'," +
                         "CompletedStatus = N'" + completedStatus + "'," +
                         "Reason = N'" + reasonPrev + "'," +
                         "EditedAt = N'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                         "EditedBy = N'" + username + "'" +
                         " WHERE Id = N'" + idPrev + "';";
                }
                SqlCommand command = new SqlCommand(query);
                command.Connection = cn;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex) { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return result;
        }

        public bool ScanOut(string idCurrent, DateTime timeEndCurrent, float dryingTimeCurrent, int resultStatusCurrent, string reasonCurrent, int completedStatusCurrent, string username, string barcode, string partNumber, int stepNoNext, float dryingTimeNext, int resultStatusNext, int completedStatusNext, int statusNext, SqlConnection cn)
        {
            bool result = false;
            try
            {
                string query = "UPDATE Productions SET " +
                    "ScanOut = N'" + timeEndCurrent.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                    "DryingTime = N'" + dryingTimeCurrent.ToString() + "'," +
                    "ResultStatus = N'" + resultStatusCurrent + "'," +
                    "CompletedStatus = N'" + completedStatusCurrent + "'," +
                    "Reason = N'" + reasonCurrent + "'," +
                    "EditedAt = N'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                    "EditedBy = N'" + username + "'" +
                    " WHERE Id = N'" + idCurrent + "';";
                if (dryingTimeNext > 0)
                {
                    query += "INSERT INTO Productions(Id, Barcode, PartNumber, StepNo, ScanIn, Limit, DryingTime, ResultStatus, CompletedStatus, Status, CreatedAt, CreatedBy) VALUES(N'" +
                        Guid.NewGuid().ToString() + "', N'" +
                        barcode + "', N'" +
                        partNumber + "', N'" +
                        stepNoNext + "', N'" +
                        timeEndCurrent.ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                        timeEndCurrent.AddMinutes(dryingTimeNext).ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                        0 + "', N'" +
                        resultStatusNext + "', N'" +
                        completedStatusNext + "', N'" +
                        statusNext + "', N'" +
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                        username + "');";
                }
                SqlCommand command = new SqlCommand(query);
                command.Connection = cn;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex) { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return result;
        }

        public bool StockOut(string barcode, string partNumber, int status, string username, SqlConnection cn)
        {
            bool result = false;
            try
            {
                string query = "INSERT INTO StockOuts(Id, ScanDate, PartNumber, Barcode, UserID, Status, CreatedAt, CreatedBy) VALUES(N'" +
                    Guid.NewGuid().ToString() + "', N'" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                    partNumber + "', N'" +
                    barcode + "', N'" +
                    username + "', N'" +
                    status + "', N'" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', N'" +
                    username + "');";
                SqlCommand command = new SqlCommand(query);
                command.Connection = cn;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex) { }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            return result;
        }
        #endregion
    }
}