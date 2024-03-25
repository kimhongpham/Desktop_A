using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gaming_Dashboard
{
    public partial class BangXepHang : UserControl
    {
        public BangXepHang()
        {
            InitializeComponent();
            // Query data
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(
                        "SELECT U.UserName, G.GameID, G.Score " +
                        "FROM (" +
                            "SELECT GameID, MAX(Score) as Score, UserID " +
                            "FROM GameSessions " +
                            "GROUP BY GameID, UserID " +
                        ") G JOIN GameSessions S on G.UserID = S.UserID AND G.GameID = S.GameID " +
                        "JOIN Users U ON G.UserID = U.UserID",
                        sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    int labelIndex = 0;
                    while (reader.Read())
                    {
                        int gameID = (int)reader["GameID"];

                        // Update UserName label
                        Control userNameLabel = pnl_1.Controls[$"lbl_1_{labelIndex}"];
                        lbl_1.Text = reader["UserName"].ToString();

                        // Update Score label
                        Control scoreLabel = pnl_1.Controls[$"lbl_s1_{labelIndex}"];
                        lnl_s1.Text = $"Score: {reader["Score"]}";

                        labelIndex++;
                    }

                    sqlConnection.Close();
                }
            }
        }
        private static BangXepHang _instance;
        public static BangXepHang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BangXepHang();
                return _instance;
            }
        }
        private void BangXepHang_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
