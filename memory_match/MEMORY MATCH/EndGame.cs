using admin___tke;
using MEMORY_MATCH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMORY_MATCH
{
    public partial class EndGame : Form
    {
        private MainGame maingame;
        public EndGame(MainGame maingame)
        {
            InitializeComponent();
            this.maingame = maingame;
        }

        private void btn_mainoption_Click(object sender, EventArgs e)
        {
            this.Close();
            maingame.Close();
        }

        private void EndGame_Load(object sender, EventArgs e)
        {
            label2.Text = "Score: " + maingame.score;
            label3.Text = "Level: " + maingame.level;
            //cập nhật điểm vào Score của GameSessionID hiện tại (maingame) trong bảng GameSessions
            // lấy ra Score cao nhất trong bảng GameSessions ứng với GameID=1 và in ra label4.
            //int currentGameSessionID = GetCurrentGameSessionID(); // Lấy GameSessionID hiện tại từ form Maingame

            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                // Lấy max GameSessionID
                int maxGameSessionID = 0;
                string query = "SELECT MAX(GameSessionID) FROM GameSessions";
                SqlCommand command2 = new SqlCommand(query, sqlConnection);
                object result = command2.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxGameSessionID = Convert.ToInt32(result);
                }

                // Cập nhật điểm số (Score), thời gian kết thúc vào bảng GameSessions
                string updateScoreQuery = "UPDATE GameSessions SET Score = @Score, EndDate = @EndDate WHERE GameSessionID = @GameSessionID";
                using (SqlCommand command = new SqlCommand(updateScoreQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@Score", maingame.score);
                    command.Parameters.AddWithValue("@EndDate", DateTime.Now);
                    command.Parameters.AddWithValue("@GameSessionID", maxGameSessionID);
                    command.ExecuteNonQuery();
                }

                // Lấy ra điểm số cao nhất (MaxScore) từ bảng GameSessions ứng với GameID=1
                string getMaxScoreQuery = "SELECT MAX(Score) FROM GameSessions WHERE GameID = 1";
                using (SqlCommand command = new SqlCommand(getMaxScoreQuery, sqlConnection))
                {
                    object maxScoreResult = command.ExecuteScalar();
                    int maxScore = maxScoreResult != DBNull.Value ? Convert.ToInt32(maxScoreResult) : 0;
                    label4.Text = "Highest Score: " + maxScore;
                }

                sqlConnection.Close();
            }
        }
        //private int GetCurrentGameSessionID()
        //{
        //    // Thay thế đoạn code này bằng cách lấy GameSessionID hiện tại từ form Maingame
        //    int currentGameSessionID = 34; // Ví dụ: Lấy GameSessionID = 4
        //    return currentGameSessionID;
        //}

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Close();
            PlayAgain playagain = new PlayAgain(maingame);
            playagain.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //private int GetUserIdFromUsername(string username)
        //{
        //    // Create a connection to the database
        //    //string connectionString = "Data Source=ROSIE-PHAM\\SQLEXPRESS;Initial Catalog=game_databaseA;Initial Catalog=game_databaseA;Persist Security Info=False;User ID=rosie0107;Password=@hong0107;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        //    int userId = -1;
        //    using (SqlConnection sqlConnection = Kết_nối.getConnection())
        //    {
        //        sqlConnection.Open();

        //        // Create a command to retrieve the user's ID from the database
        //        string selectCommand = "SELECT TOP 1 UserID FROM UserGames ORDER BY UserID DESC";
        //        using (SqlCommand command = new SqlCommand(selectCommand, sqlConnection))
        //        {
        //            // Set the parameter value for the command
        //            command.Parameters.AddWithValue("@UserName", username);

        //            // Execute the command and retrieve the user's ID
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    userId = reader.GetInt32(0);
        //                }
        //            }
        //        }
        //        sqlConnection.Close();
        //    }

        //    return userId;
        //}
    }
}
//using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
//{
//    sqlConnection.Open();
//    int userId = GetUserIdFromUsername("username"); // Thay "username" bằng tên người chơi

//    // Thực thi truy vấn UPDATE
//    string updateCommand = "UPDATE GameSessions SET Score = @Score WHERE UserID = @UserID";
//    using (SqlCommand command = new SqlCommand(updateCommand, sqlConnection))
//    {
//        // Thiết lập các tham số cho truy vấn
//        command.Parameters.AddWithValue("@Score", maingame.score);
//        //command.Parameters.AddWithValue("@MaxLevel", maingame.level);
//        command.Parameters.AddWithValue("@UserID", userId);

//        // Thực thi truy vấn UPDATE
//        command.ExecuteNonQuery();
//    }
//    // Lấy giá trị MaxScore cao nhất của GameID = 1
//    string selectCommand = "SELECT MAX(Score) FROM UserGames WHERE GameID = 1";
//    using (SqlCommand command = new SqlCommand(selectCommand, sqlConnection))
//    {
//        // Thực hiện truy vấn và lấy giá trị MaxScore cao nhất
//        object result = command.ExecuteScalar();

//        if (result != null && result != DBNull.Value)
//        {
//            int maxScore = Convert.ToInt32(result);

//            // Hiển thị giá trị MaxScore cao nhất trên label4.Text
//            label4.Text = "Record: " + maxScore.ToString();
//        }
//    }
//    sqlConnection.Close();
//}
////label4.Text=" Record: "+ 
