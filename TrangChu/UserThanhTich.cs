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
using Guna.UI2.WinForms;

namespace Gaming_Dashboard
{
    public partial class UserThanhTich : UserControl
    {
        public UserThanhTich()
        {
            InitializeComponent();
        }
        private static UserThanhTich _instance;
        public static UserThanhTich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserThanhTich();
                return _instance;
            }
        }

        public void DisplayHighestScores(string username)
        {
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                // Tạo lệnh lấy điểm cao nhất của người dùng từ cơ sở dữ liệu
                string selectCommand = "SELECT g.GameName, MAX(gs.Score) as HighestScore FROM GameSessions gs JOIN Users u ON gs.UserID = u.UserID JOIN UserGames ug ON gs.GameID = ug.GameID JOIN Games g ON gs.GameID = g.GameID WHERE u.UserName = @UserName GROUP BY g.GameName ORDER BY HighestScore DESC";
                using (SqlCommand command = new SqlCommand(selectCommand, sqlConnection))
                {
                    // Đặt giá trị tham số cho lệnh
                    command.Parameters.AddWithValue("@UserName", username);

                    // Thực hiện lệnh và lấy kết quả
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Xóa các điều khiển guna2Panel trước khi hiển thị kết quả mới
                        guna2Panel9.Controls.Clear();
                        guna2Panel2.Controls.Clear();
                        guna2Panel3.Controls.Clear();

                        // Thêm kết quả vào điều khiển guna2Panel
                        int panelIndex = 0;
                        while (reader.Read())
                        {
                            // Tạo nhãn mới cho tên trò chơi và điểm số
                            Label gameLabel = new Label();
                            gameLabel.Text = $"{reader["GameName"]}: {reader["HighestScore"]}";
                            gameLabel.AutoSize = true;
                            gameLabel.Location = new Point(10, 10 + (panelIndex * 20));

                            // Thêm nhãn vào điều khiển guna2Panel thích hợp
                            switch (panelIndex)
                            {
                                case 0:
                                    guna2Panel9.Controls.Add(gameLabel);
                                    break;
                                case 1:
                                    guna2Panel2.Controls.Add(gameLabel);
                                    break;
                                case 2:
                                    guna2Panel3.Controls.Add(gameLabel);
                                    break;
                            }

                            // Tăng chỉ số bảng điều khiển
                            panelIndex++;
                        }
                    }
                }
                sqlConnection.Close();
            }
        }
    }
}