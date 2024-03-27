using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;
using Game02;
using MEMORY_MATCH;
using Codecool.Quest;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using admin___tke;
using System.Data.SqlClient;

namespace Gaming_Dashboard
{
    public partial class Main : Form
    {

        public SoundManager sound = new SoundManager(@"C:\Users\Admin\Documents\Tài liệu\ueh\phát triển ứng dụng desktop\Desktop_A\TrangChu\Resources\welcome_soundtrack.mp3");
        private string _username;

        public Main()
        {
            InitializeComponent();
            DangKy1.Instance.BackButtonClicked += DangKy1_BackButtonClicked;
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
        private void DangKy1_BackButtonClicked(object sender, EventArgs e)
        {
            // Go to the main page
            pn_TrangChuMain.BringToFront();

            // Remove the DangKy1 form
            if (pn_TrangChu2.Controls.Contains(DangKy1.Instance))
                pn_TrangChu2.Controls.Remove(DangKy1.Instance);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(DangNhap.Instance))
            {
                pn_TrangChu2.Controls.Add(DangNhap.Instance);
                DangNhap.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();    
                AutoScroll = false;
                DangNhap.Instance.BringToFront();
            }
            else
                AutoScroll = true;
                DangNhap.Instance.BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(DangKy1.Instance))
            {
                pn_TrangChu2.Controls.Add(DangKy1.Instance);
                DangKy1.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                DangKy1.Instance.BringToFront();
            }
            else
                AutoScroll = true;
                DangKy1.Instance.BringToFront();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            sound.Play();
        }

        private void guna2Panel15_Paint(object sender, PaintEventArgs e)
        {
            pn_TrangChu2.BackColor = Color.FromArgb(100, 0, 0, 0);
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            AutoScroll = true;
            pn_TrangChuMain.BringToFront();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(DangKy1.Instance))
            {
                pn_TrangChu2.Controls.Add(DangKy1.Instance);
                DangKy1.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                DangKy1.Instance.BringToFront();
            }
            else
                DangKy1.Instance.BringToFront();
        }

        private void imgBtn_logo_Click(object sender, EventArgs e)
        {
            AutoScroll = true;
            pn_TrangChuMain.BringToFront();

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(DangNhap.Instance))
            {
                pn_TrangChu2.Controls.Add(DangNhap.Instance);
                DangNhap.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                AutoScroll = false;
                DangNhap.Instance.BringToFront();
            }
            else
                pn_TrangChu2.BringToFront();
                DangNhap.Instance.BringToFront();

            DangNhap.Instance.main = this;
        }
        

        private void btn_DangKy_Click_1(object sender, EventArgs e)
        {
            if (!pn_TrangChu2.Controls.Contains(DangKy1.Instance))
            {
                pn_TrangChu2.Controls.Add(DangKy1.Instance);
                DangKy1.Instance.Dock = DockStyle.Fill;
                pn_TrangChu2.BringToFront();
                 AutoScroll = false;
                DangKy1.Instance.BringToFront();
            }
            else
                pn_TrangChu2.BringToFront();
            DangKy1.Instance.BringToFront();
            DangKy1.Instance.main = this;
        }

        private void lbl_BangXepHangMain_Click(object sender, EventArgs e)
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


        private void imgBtn_CaiDat_Click(object sender, EventArgs e)
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

        private void imgBtn_YeuThich_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yêu cầu đăng nhập!");
        }

        private void imgBtn_ThongBao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yêu cầu đăng nhập!");
        }


        private void btn_Game1_Click(object sender, EventArgs e)
        {
            var MainOption = new MEMORY_MATCH.MainOption(); // tạo một phiên bản mới của Main Game 1
            MainOption.ShowDialog();
        }

        private void btn_game2_Click(object sender, EventArgs e)
        {
            var mainMenu = new Game02.MainMenu(_username); // tạo một phiên bản mới của Main Game 2
            mainMenu.ShowDialog(); // hiển thị mẫu Main Game 2
        }

        private void btn_game3_Click(object sender, EventArgs e)
        {
            // Pass the `_username` variable to the MainForm constructor
            var MainForm = new Codecool.Quest.MainForm(_username);
            MainForm.ShowDialog(); // hiển thị mẫu Main Game 3
        }

    }
}
