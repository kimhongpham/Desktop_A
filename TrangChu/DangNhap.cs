using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gaming_Dashboard
{
    public partial class DangNhap : UserControl
    {

        private UserControl previousUserControl;
        public DangNhap()
        {
            InitializeComponent();
        }
        private static DangNhap _instance;
        public static DangNhap Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DangNhap();
                return _instance;
            }
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!pn_DangNhap2.Controls.Contains(QuenMatKhau.Instance))
            {
                pn_DangNhap2.Controls.Add(QuenMatKhau.Instance);
                QuenMatKhau.Instance.Dock = DockStyle.Fill;
                pn_DangNhap2.BringToFront();
                AutoScroll = false;
                QuenMatKhau.Instance.BringToFront();
            }
            else
                pn_DangNhap.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        public void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!pn_DangNhap2.Controls.Contains(DangKy1.Instance))
            {
                pn_DangNhap2.Controls.Add(DangKy1.Instance);
                DangKy1.Instance.Dock = DockStyle.Fill;
                pn_DangNhap2.BringToFront();
                AutoScroll = false;
                DangKy1.Instance.BringToFront();
            }
            else
                pn_DangNhap.BringToFront();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbl_DangNhap_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_MatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
