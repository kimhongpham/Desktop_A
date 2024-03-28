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

namespace MEMORY_MATCH
{
    public partial class GameOver : Form
    {
        private MainGame maingame;
        public GameOver(MainGame maingame)
        {
            InitializeComponent();
            this.maingame = maingame;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Close();
            PlayAgain playagain = new PlayAgain(maingame);
            playagain.Show();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            label2.Text = "Score: " + maingame.score;
            label3.Text = "Level: " + maingame.level;
            //cập nhật điểm vào Score của GameSessionID hiện tại (maingame) trong bảng GameSessions
            // lấy ra Score cao nhất trong bảng GameSessions ứng với GameID=1 và in ra label4.

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

        private void btn_mainoption_Click(object sender, EventArgs e)
        {
            maingame.Close();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
