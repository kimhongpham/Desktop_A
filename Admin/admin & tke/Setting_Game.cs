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
    }   
}
