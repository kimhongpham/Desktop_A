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

namespace Gaming_Dashboard
{
    public partial class UserTroChoiYeuThich : UserControl
    {
        public UserTroChoiYeuThich()
        {
            InitializeComponent();
        }
        private static UserTroChoiYeuThich _instance;
        public static UserTroChoiYeuThich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserTroChoiYeuThich();
                return _instance;
            }
        }
        private void guna2PictureBox22_Click(object sender, EventArgs e)
        {

        }
        private void DisplayUserRankings()
        {
            // Connect to the database
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                // Xác định truy vấn SQL
                string query = @"
            SELECT u.UserID, g.GameName, g.GameID, COUNT(*) as PlayCount,
                ROW_NUMBER() OVER (PARTITION BY g.GameID ORDER BY COUNT(*) DESC) as Rank
            FROM UserGames ug
            JOIN GameSessions gs ON ug.GameID = gs.GameID
            JOIN Users u ON ug.UserID = u.UserID
            JOIN Games g ON ug.GameID = g.GameID
            GROUP BY u.UserID, g.GameName, g.GameID
            ORDER BY g.GameID, PlayCount DESC;
        ";

                // Thực hiện truy vấn SQL
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Hiển thị dữ liệu trong ba điều khiển guna2Panel
                        int panelIndex = 0;
                        int currentGameID = -1;
                        while (reader.Read())
                        {
                            // Lấy dữ liệu từ SqlDataReader
                            int userID = reader.GetInt32(0);
                            string gameName = reader.GetString(1);
                            int gameID = reader.GetInt32(2);
                            int playCount = reader.GetInt32(3);
                            int rank = reader.GetInt32(4);

                            // Hiển thị thứ hạng cho trò chơi hiện tại
                            if (currentGameID == gameID)
                            {
                                // Đặt văn bản của điều khiển guna2Panel
                                guna2Panel9.Text = $"{gameName} (Rank {rank})";
                                guna2Panel9.Tag = userID;

                                guna2Panel2.Text = $"{gameName} (Rank {rank + 1})";
                                guna2Panel2.Tag = userID;

                                guna2Panel3.Text = $"{gameName} (Rank {rank + 2})";
                                guna2Panel3.Tag = userID;

                                panelIndex++;
                            }
                            else
                            {
                                // Đặt lại chỉ mục bảng điều khiển và đặt ID trò chơi hiện tại
                                panelIndex = 0;
                                currentGameID = gameID;
                            }
                        }
                    }
                }

                sqlConnection.Close();
            }
        }
    }
}