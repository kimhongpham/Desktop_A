using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admin___tke
{
    public partial class Admin_Player : Form
    {
        public Admin_Player()
        {
            InitializeComponent();
        }

        private void btn_Edit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Edit_info f2 = new Edit_info();
            f2.ShowDialog();
        }

        private void btn_GPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Game admin_Game = new Admin_Game();
            admin_Game.Show();
        }
    }
}
