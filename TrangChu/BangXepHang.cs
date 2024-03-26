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
            ") G JOIN GameSessions S on G.GameID = S.GameID AND G.Score = S.Score " +
            "JOIN Users U ON G.UserID = U.UserID",
                        sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    int labelIndex1 = 0;
                    int panelIndex1 = 1;
                    int labelIndex2 = 0;
                    int panelIndex2 = 2;
                    int labelIndex3 = 0;
                    int panelIndex3 = 3;

                    while (reader.Read())
                    {
                        int gameID = (int)reader["GameID"];

                        if (gameID == 1)
                        {
                            // Update UserName label for panel 1
                            Control userNameLabel = pnl_1.Controls[$"lbl_1_{labelIndex1}"];
                            lbl_1.Text = reader["UserName"].ToString();

                            // Update Score label for panel 1
                            Control scoreLabel = pnl_1.Controls[$"lbl_s1_{labelIndex1}"];
                            lnl_s1.Text = $"Score: {reader["Score"]}";

                            labelIndex1++;
                        }
                        else if (gameID == 2 && panelIndex2 == 2)
                        {
                            // Update UserName label for panel 2
                            Control userNameLabel = pnl_2.Controls[$"lbl_1_{labelIndex2}"];
                            lbl2.Text = reader["UserName"].ToString();

                            // Update Score label for panel 2
                            Control scoreLabel = pnl_2.Controls[$"lbl_s1_{labelIndex2}"];
                            lbl_s2.Text = $"Score: {reader["Score"]}";

                            labelIndex2++;
                            panelIndex2++;
                        }
                        else if (gameID == 3 && panelIndex3 == 3)
                        {
                            // Update UserName label for panel 3
                            Control userNameLabel = pnl_3.Controls[$"lbl_1_{labelIndex3}"];
                            lbl_3.Text = reader["UserName"].ToString();

                            // Update Score label for panel 3
                            Control scoreLabel = pnl_3.Controls[$"lbl_s1_{labelIndex3}"];
                            lnl_s3.Text = $"Score: {reader["Score"]}";

                            labelIndex3++;
                            panelIndex3++;
                        }
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
