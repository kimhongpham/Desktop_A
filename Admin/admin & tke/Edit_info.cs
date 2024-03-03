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
    public partial class Edit_info : Form
    {
        public Edit_info()
        {
            InitializeComponent();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            
            Admin_Player admin_Player = new Admin_Player();
            admin_Player.Show();
            this.Close();
        }
    }
}
