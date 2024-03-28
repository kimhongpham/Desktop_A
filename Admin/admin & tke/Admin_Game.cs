using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using ZedGraph;
using System.IO;

namespace admin___tke
{
    public partial class Admin_Game : Form
    {
        private int currentPage = 1;
        private int pageSize = 3;
        private int totalRecords;
        public Admin_Game()
{
    InitializeComponent();

    // Connect to the database
    using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
    {
        sqlConnection.Open();

        // Insert data into lblName_G1 and lbl_des1 for gameid = 1
        string query1 = "SELECT GameName, GameDescription FROM Games WHERE GameID = 1";
        SqlCommand sqlCommand1 = new SqlCommand(query1, sqlConnection);
        using (SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader())
        {
            if (sqlDataReader.Read())
            {
                lblName_G1.Text = sqlDataReader.GetString(0);
                lbl_des1.Text = sqlDataReader.IsDBNull(1) ? "" : sqlDataReader.GetString(1);
            }
        }

        // Insert data into label3 and label2 for gameid = 2
        string query2 = "SELECT GameName, GameDescription FROM Games WHERE GameID = 2";
        SqlCommand sqlCommand2 = new SqlCommand(query2, sqlConnection);
        using (SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader())
        {
            if (sqlDataReader.Read())
            {
                label3.Text = sqlDataReader.GetString(0);
                label2.Text = sqlDataReader.IsDBNull(1) ? "" : sqlDataReader.GetString(1);
            }
        }
    }
}

        private void btn_SettingG1_Click(object sender, EventArgs e)
        {


        }

        private void btn_SettingG2_Click(object sender, EventArgs e)
        {
            this.Close();
            Setting_Game setting_Game = new Setting_Game();
            setting_Game.Show();
        }

        private void btn_GamePage_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_Player admin_Player = new Admin_Player();
            admin_Player.Show();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            string gameName = txt_Search.Text;

            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT GameName, GameDescription FROM Games WHERE GameName = @gameName";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@gameName", gameName);

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        lblName_G1.Text = sqlDataReader.GetString(0);
                        lbl_des1.Text = sqlDataReader.IsDBNull(1) ? "" : sqlDataReader.GetString(1);

                        // Remove guna2Panel1 from the form
                        this.Controls.Remove(guna2Panel1);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy trò chơi", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                sqlConnection.Close();
            }
        }

        private void populateGameInfo(SqlDataReader sqlDataReader)
        {
            if (sqlDataReader.Read())
            {
                string gameID = sqlDataReader["GameID"].ToString();
                lblGameID.Text = gameID;
                lblName_G1.Text = sqlDataReader["GameName"].ToString();
                lbl_des1.Text = sqlDataReader["GameDescription"].ToString();
                // ReleaseDate.Value = (DateTime)sqlDataReader["NGAYPHATHANH"];
            }
        }

        private void btn_Thêm_Click(object sender, EventArgs e)
        {
            this.Close();
            Setting_Game setting_Game = new Setting_Game();
            setting_Game.Show();
        }

        private void Admin_Game_Load(object sender, EventArgs e)
        {

        }

        private int _currentPage = 1;
        private int _pageSize = 10; // Rename the variable to have a unique name

        private void btn_P2_Click(object sender, EventArgs e)
        {
            _currentPage++;
            LoadGames();
        }

        private void LoadGames()
        {
            int offset = (currentPage - 1) * pageSize; // Calculate the offset based on the current page
            string gameName = txt_Search.Text;

            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT GameName, GameDescription FROM Games WHERE GameName = @gameName " +
                               "ORDER BY GameName OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@gameName", gameName);
                sqlCommand.Parameters.AddWithValue("@offset", offset);
                sqlCommand.Parameters.AddWithValue("@pageSize", pageSize);

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        lblName_G1.Text = sqlDataReader.GetString(0);
                        lbl_des1.Text = sqlDataReader.IsDBNull(1) ? "" : sqlDataReader.GetString(1);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy trò chơi", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                sqlConnection.Close();
            }
        }
    }
}
