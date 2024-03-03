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

namespace Gaming_Dashboard
{
    public partial class Main : Form
    {

        public SoundManager sound = new SoundManager(@"D:\github_repo\Game-Dashboard-GabiBox\Resources\welcome_soundtrack.mp3");
        public Main()
        {
            InitializeComponent();
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

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void pn_TrangChu_Paint(object sender, PaintEventArgs e)
        {

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

        private void btn_ChoiNgayMain_Click(object sender, EventArgs e)
        {

        }
        private void label19_Click(object sender, EventArgs e)
        {
            
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TopGameMain_Click(object sender, EventArgs e)
        {

        }
    }
}
