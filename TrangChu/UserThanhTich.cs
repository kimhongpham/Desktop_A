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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaming_Dashboard
{
    public partial class UserThanhTich : UserControl
    {
        private string _username;
        public UserThanhTich(string username)
        {
            InitializeComponent();
            _username = username;
            LoadUserScores();
        }
        private static UserThanhTich _instance;
        public static UserThanhTich Instance(string username)
        {
            if (_instance == null)
                _instance = new UserThanhTich(username);
            return _instance;
        }
        private int GetUserIdFromUsername(string username)
        {
            // Tạo kết nối tới cơ sở dữ liệu
            int userId = -1;
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                // Tạo lệnh truy xuất ID người dùng từ cơ sở dữ liệu
                string selectCommand = "SELECT UserID FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(selectCommand, sqlConnection))
                {
                    // Đặt giá trị tham số cho lệnh
                    command.Parameters.AddWithValue("@UserName", username);

                    // Thực hiện lệnh và lấy ID người dùng
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                        }
                    }
                }
                sqlConnection.Close();
            }

            return userId;
        }
        private void LoadUserScores()
        {
            // Lấy ID người dùng từ tên người dùng
            int userId = GetUserIdFromUsername(_username);

            // Xác định truy vấn SQL để lấy điểm và xếp hạng cao nhất cho mỗi trò chơi
            string selectCommand = @"SELECT GameID, GameName, HighestScore, Ranking
                                   FROM (SELECT GameID, GameName, UserID, HighestScore,RANK() OVER (PARTITION BY GameID ORDER BY HighestScore DESC) AS Ranking
                                        FROM (SELECT g.GameID, g.GameName, gs.UserID, MAX(gs.Score) AS HighestScore
                                            FROM GameSessions gs
                                            JOIN Games g ON gs.GameID = g.GameID
                                            GROUP BY g.GameID, g.GameName, gs.UserID) AS subquery) AS ranks
                                            WHERE UserID = @UserID
                                            ORDER BY GameID; ";

            // Thực hiện truy vấn và hiển thị kết quả trong nhãn và nút
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(selectCommand, sqlConnection))
                {
                    // Đặt giá trị của tham số ID người dùng
                    command.Parameters.AddWithValue("@UserID", userId);

                    // Thực hiện lệnh và lấy trình đọc dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int gameId = 1;
                        while (gameId <= 3)
                        {
                            // Kiểm tra xem có bản ghi nào được trả về
                            if (reader.HasRows)
                            {
                                // Nếu có bản ghi, đọc các giá trị từ trình đọc dữ liệu
                                // và đặt chúng vào nhãn và nút
                                if (reader.Read())
                                {
                                    string gameName = reader.GetString(1);
                                    long highestScore = reader.GetInt64(2);
                                    object ranking = reader.GetValue(3);
                                    int rank = Convert.ToInt32(ranking);

                                    if (gameId == 1)
                                    {
                                        label1.Text = highestScore.ToString();
                                        btn1.Text = rank.ToString();
                                    }
                                    else if (gameId == 2)
                                    {
                                        label2.Text = highestScore.ToString();
                                        btn2.Text = rank.ToString();
                                    }
                                    else if (gameId == 3)
                                    {
                                        label3.Text = highestScore.ToString();
                                        btn3.Text = rank.ToString();
                                    }
                                }
                            }
                            else
                            {
                                // Nếu không có bản ghi, đặt điểm và xếp hạng mặc định
                                if (gameId == 1)
                                {
                                    label1.Text = "0";
                                    btn1.Text = "0";
                                }
                                else if (gameId == 2)
                                {
                                    label2.Text = "0";
                                    btn2.Text = "0";
                                }
                                else if (gameId == 3)
                                {
                                    label3.Text = "0";
                                    btn3.Text = "0";
                                }
                            }

                            gameId++;
                        }
                    }
                }

                sqlConnection.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }
    }
}