using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryManagement.DataAccess
{
    public class DBHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public static object ExecuteScalar(string query, SqlParameter[] sqlParameters = null)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ExecuteNonQuery(string query, SqlParameter[] sqlParameters = null)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if(sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] sqlParameters = null,bool isSp=false)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    if (isSp)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    }
                    else
                    {
                        command.CommandType = CommandType.Text;
                    }
                    if(sqlParameters != null)
                    {
                        command.Parameters.AddRange(sqlParameters); 
                    }
                    connection.Open();
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}