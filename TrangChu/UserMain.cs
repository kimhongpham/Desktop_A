using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Game02;
using MEMORY_MATCH;
using Codecool.Quest;
using System.Data.SqlClient;

namespace Gaming_Dashboard
{
    public partial class UserMain : Form
    {
        
        
        public SoundManager sound = new SoundManager(@"D:\github_repo\Game-Dashboard-GabiBox\Resources\welcome_soundtrack.mp3");
        private string _username; // khai báo một trường riêng tư để lưu trữ tên người dùng
        private int _userID;

        public UserMain(string username) // sửa đổi hàm tạo để chấp nhận tham số tên người dùng
        {
            InitializeComponent();
            _username = username; // đặt trường riêng tư thành tên người dùng
            lbl_Username.Text = _username; // đặt văn bản của nhãn thành tên người dùng
            label6.Text = GetTotalGameSessionID(1).ToString();
            label12.Text = GetTotalGameSessionID(2).ToString();
            label15.Text = GetTotalGameSessionID(3).ToString();
        }

        private int GetTotalGameSessionID(int gameId)
        {
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                using (var command = new SqlCommand("SELECT COUNT(*) FROM GameSessions WHERE GameID = @GameID", sqlConnection))
                {
                    command.Parameters.AddWithValue("@GameID", gameId);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(UserTaiKhoan.Instance(_username)))
            {
                pn_TrangChu2.Controls.Add(UserTaiKhoan.Instance(_username));
                UserTaiKhoan.Instance(_username).Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                UserTaiKhoan.Instance(_username).BringToFront();
            }
            else
                UserTaiKhoan.Instance(_username).BringToFront();
        }

        

        private void UserMain_Load(object sender, EventArgs e)
        {
            sound.Play();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(UserTaiKhoan.Instance(_username)))
            {
                pn_TrangChu2.Controls.Add(UserTaiKhoan.Instance(_username));
                UserTaiKhoan.Instance(_username).Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                UserTaiKhoan.Instance(_username).BringToFront();
            }
            else
                AutoScroll = false;
            pn_TrangChu2.BringToFront();
            UserTaiKhoan.Instance(_username).BringToFront();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            AutoScroll = true;
            //pn_TrangChu2.Visible = true;  
            pn_TrangChuMain.BringToFront();  
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(UserCaiDat.Instance))
            {
                pn_TrangChu2.Controls.Add(UserCaiDat.Instance);
                UserCaiDat.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                UserCaiDat.Instance.BringToFront();
            }
            else
                UserCaiDat.Instance.BringToFront();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            AutoScroll = true;
           // pn_TrangChu2.Visible = true;
            pn_TrangChuMain.BringToFront();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(UserTroChoiYeuThich.Instance))
            {
                pn_TrangChu2.Controls.Add(UserTroChoiYeuThich.Instance);
                UserTroChoiYeuThich.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                UserTroChoiYeuThich.Instance.BringToFront();
            }
            else
                pn_TrangChu2.BringToFront();
                UserTroChoiYeuThich.Instance.BringToFront();
        }

        private void guna2PictureBox13_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(UserThongBao.Instance))
            {
                pn_TrangChu2.Controls.Add(UserThongBao.Instance);
                UserThongBao.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                UserThongBao.Instance.BringToFront();
            }
            else
               pn_TrangChu2.BringToFront();
                UserThongBao.Instance.BringToFront();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
         
        }

        private void label29_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(BangXepHang.Instance))
            {
                pn_TrangChu2.Controls.Add(BangXepHang.Instance);
                BangXepHang.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                BangXepHang.Instance.BringToFront();
            }
            else
                BangXepHang.Instance.BringToFront();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            
        }

        private void label30_Click(object sender, EventArgs e)
        {
        }

        private void btn_Game1_Click(object sender, EventArgs e)
        {
            var MainOption = new MEMORY_MATCH.MainOption(_username); // tạo một phiên bản mới của Main Game 1
            MainOption.ShowDialog();
        }

        private void btn_game3_Click(object sender, EventArgs e)
        {
            using (MainForm mainForm = new MainForm(_username))
            {
                mainForm.ShowDialog();
            }
        }

        private void btn_game2_Click(object sender, EventArgs e)
        {
            using (var mainMenu = new Game02.MainMenu(_username))
            {
                this.Hide();
                mainMenu.ShowDialog();
            }
        }
    }
}
