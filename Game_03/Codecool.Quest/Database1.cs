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
            private static string con_str = "Data Source=B508PC09;Initial Catalog=Question;Integrated Security=True";
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
                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(con_str))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý các ngoại lệ nếu cần thiết
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }

                return dt;
            }
        }
    }
