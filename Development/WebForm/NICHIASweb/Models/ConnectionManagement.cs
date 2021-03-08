using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NICHIASweb.Models
{
    public class ConnectionManagement
    {
        private SqlConnection sqlConnection;

        string sqlDefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ConnectionManagement()
        {

        }

        public SqlConnection GetDefaultConnection()
        {
            try
            {
                sqlConnection = new SqlConnection(sqlDefaultConnection);
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {

            }
            return sqlConnection;
        }
    }
}