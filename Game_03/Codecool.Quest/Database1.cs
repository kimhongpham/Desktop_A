using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Codecool.Quest
{
    public class Database1
    {
        private static string con_str = "Data Source=DESKTOP-HRCOHGR\\SQLEXPRESS;Initial Catalog=Question;Integrated Security=True";
        private static SqlConnection connection;
        private static SqlCommand command;
        public static SqlConnection CreateConnection()
        {
            try
            {
                connection = new SqlConnection(con_str);
                connection.Open();
            }
            catch
            {
                connection = null;
            }
            return connection;
        }
        public static SqlCommand CreateCommand(string commandText, SqlConnection connection)
        {
            try
            {
                command = new SqlCommand(commandText, CreateConnection());
            }
            catch { command = null; }
            return command;
        }
        public static DataTable SelectQuery(string sql)
        {
            command = CreateCommand(sql, null);
            SqlDataAdapter adt = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            command.Dispose();
            adt.Dispose();
            return dt;
        }
    }
}
