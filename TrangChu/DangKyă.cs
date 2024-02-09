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
    public partial class DangKy1 : UserControl
    {
        public event EventHandler BackButtonClicked;
        private static DangKy1 _instance;
        public static DangKy1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DangKy1();
                return _instance;
            }
        }
        public DangKy1()
        {
            InitializeComponent();
        }

        private void DangKy1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
