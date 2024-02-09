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
    public partial class QuenMatKhau : UserControl
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        private static QuenMatKhau _instance;
        public static QuenMatKhau Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QuenMatKhau();
                return _instance;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!guna2Panel2.Controls.Contains(DoiMatKhau.Instance))
            {
                guna2Panel2.Controls.Add(DoiMatKhau.Instance);
                DoiMatKhau.Instance.Dock = DockStyle.Fill;
                guna2Panel2.BringToFront();
                AutoScroll = false;
                DoiMatKhau.Instance.BringToFront();
            }
            else
                DoiMatKhau.Instance.BringToFront();
        }
    }
    
}
