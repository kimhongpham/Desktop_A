using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin___tke
{
    public class Kết_nối
    {
        private static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "ROSIE-PHAM\\SQLEXPRESS",
            InitialCatalog = "game_databaseA",
            IntegratedSecurity = true,
            Encrypt = true,
            TrustServerCertificate = true
        };

        public static SqlConnection getConnection()
        {
            return new SqlConnection(builder.ConnectionString);
        }
    }
}
