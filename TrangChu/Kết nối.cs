using System.Data.SqlClient;

namespace Gaming_Dashboard
{
    internal class Kết_nối
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