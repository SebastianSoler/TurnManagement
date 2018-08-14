using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Propago.Net.CrossCutting.DDBBUtils
{
    public static class DDBBAccess
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["TurnManagementConnection"].ToString();

        public static string GetDatabaseName()
        {
            return new SqlConnection(connectionString).Database;
        }

        public static int ExecuteNonQuery(string query, IList<SqlParameter> parameters = null, int? customTimeOut = null)
        {
             return GetSqlCommand(query, parameters, customTimeOut).ExecuteNonQuery();
        }

        public static SqlDataReader ExecuteQuery(string query, IList<SqlParameter> parameters = null, int? customTimeOut = null)
        {
            return GetSqlCommand(query, parameters, customTimeOut).ExecuteReader();
        }

        public static bool ValidateDBConnection()
        {
            bool resp = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    resp = true;
                }
            }
            catch (SqlException){ resp = false; }

            return resp;
        }

        private static SqlCommand GetSqlCommand(string commandText, IList<SqlParameter> parameters = null, int? customTimeOut = null)
        {            
            var command = new SqlCommand();

            command.Connection = new SqlConnection(connectionString);
            command.CommandTimeout = customTimeOut.HasValue ? customTimeOut.Value : command.CommandTimeout;
            command.CommandText = commandText;
            
            if (parameters != null && parameters.Any())
            {
                parameters.ToList().ForEach(param => command.Parameters.Add(param));
            }            

            command.Connection.Open();

            return command;
        }
    }
}
