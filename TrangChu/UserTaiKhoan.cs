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
    public partial class UserTaiKhoan : UserControl
    {
        public UserTaiKhoan()
        {
            InitializeComponent();
        }
        private static UserTaiKhoan _instance;
        public static UserTaiKhoan Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserTaiKhoan();
                return _instance;
            }
        }

        private void UserTaiKhoan_Load(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserThongTinCaNhan.Instance))
            {
                guna2Panel1.Controls.Add(UserThongTinCaNhan.Instance);
                UserThongTinCaNhan.Instance.Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserThongTinCaNhan.Instance.BringToFront();
            }
            else
                UserThongTinCaNhan.Instance.BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserThanhTich.Instance))
            {
                guna2Panel1.Controls.Add(UserThanhTich.Instance);
                UserThanhTich.Instance.Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserThanhTich.Instance.BringToFront();
            }
            else
                UserThanhTich.Instance.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserCaiDat.Instance))
            {
                guna2Panel1.Controls.Add(UserCaiDat.Instance);
                UserCaiDat.Instance.Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserCaiDat.Instance.BringToFront();
            }
            else
                UserCaiDat.Instance.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserThongTinCaNhan.Instance))
            {
                guna2Panel1.Controls.Add(UserThongTinCaNhan.Instance);
                UserThongTinCaNhan.Instance.Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserThongTinCaNhan.Instance.BringToFront();
            }
            else
                UserThongTinCaNhan.Instance.BringToFront();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserDoiMatKhau.Instance))
            {
                guna2Panel1.Controls.Add(UserDoiMatKhau.Instance);
                UserDoiMatKhau.Instance.Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserDoiMatKhau.Instance.BringToFront();
            }
            else
                UserDoiMatKhau.Instance.BringToFront();
        }
    }
}
