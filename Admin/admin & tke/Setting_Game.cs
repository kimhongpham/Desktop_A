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

namespace admin___tke
{
    public partial class Setting_Game : Form
    {
        public Setting_Game()
        {
            InitializeComponent();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_Game admin_Game = new Admin_Game();
            admin_Game.Show();

        }

        private void txt_NameG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Des_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string gameID = txt_gameid.Text;
            string gameName = txt_NameG.Text;
            string gameDescription = txt_Des.Text;

            // Cắt ngắn mô tả xuống độ dài tối đa 200 ký tự
            if (gameDescription.Length > 200)
            {
                gameDescription = gameDescription.Substring(0, 200);
            }

            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "INSERT INTO Games (GameID, GameName, NGAYPHATHANH, GameDescription) VALUES (@gameID, @gameName, @releaseDate, @gameDescription)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@gameID", gameID);
                sqlCommand.Parameters.AddWithValue("@gameName", gameName);
                sqlCommand.Parameters.AddWithValue("@releaseDate", DateTime.Today);
                sqlCommand.Parameters.AddWithValue("@gameDescription", gameDescription);

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }

            MessageBox.Show("Trò chơi đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pic_G_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_ChangePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.tif)|*.bmp;*.jpg;*.jpeg;*.png;*.tif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pic_G.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            // Check if the textbox is empty
            if (string.IsNullOrWhiteSpace(txt_gameid.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập vào mã trò chơi", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the gameid is a valid id
            int gameid;
            if (!int.TryParse(txt_gameid.Text.Trim(), out gameid) || gameid <= 0)
            {
                MessageBox.Show("Vui lòng nhập vào một mã trò chơi hợp lệ", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the gameid exists in the database
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT COUNT(*) FROM Games WHERE GameID = @gameid";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@gameid", gameid);
                int count = (int)sqlCommand.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã trò chơi này", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show confirmation message
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dữ liệu của trò chơi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                // Delete the game
                query = "DELETE FROM Games WHERE GameID = @gameid";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@gameid", gameid);
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công trò chơi này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textbox
                txt_gameid.Clear();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Check if the textbox is empty
            if (string.IsNullOrWhiteSpace(txt_gameid.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập vào mã trò chơi", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the gameid is a valid id
            int gameid;
            if (!int.TryParse(txt_gameid.Text.Trim(), out gameid))
            {
                MessageBox.Show("Vui lòng nhập vào một mã trò chơi hợp lệ", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the gameid exists in the database
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT COUNT(*) FROM Games WHERE GameID = @gameid";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@gameid", gameid);
                int count = (int)sqlCommand.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã trò chơi này", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update game name and description
                if (!string.IsNullOrWhiteSpace(txt_NameG.Text.Trim()))
                {
                    query = "UPDATE Games SET GameName = @gameName WHERE GameID = @gameid";
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@gameName", txt_NameG.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@gameid", gameid);
                    sqlCommand.ExecuteNonQuery();
                }

                if (!string.IsNullOrWhiteSpace(txt_Des.Text.Trim()))
                {
                    query = "UPDATE Games SET GameDescription = @gameDescription WHERE GameID = @gameid";
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@gameDescription", txt_Des.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@gameid", gameid);
                    sqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công trò chơi này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                txt_gameid.Clear();
                txt_NameG.Clear();
                txt_Des.Clear();
            }
        }
    }   
}
