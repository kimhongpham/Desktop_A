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
    public partial class Admin_Game : Form
    {
        public Admin_Game()
        {
            InitializeComponent();
            
        }

        private void btn_SettingG1_Click(object sender, EventArgs e)
        {
            this.Close();
            Setting_Game setting_Game = new Setting_Game();
            setting_Game.Show();
            
        }

        private void btn_SettingG2_Click(object sender, EventArgs e)
        {
            this.Close();
            Setting_Game setting_Game = new Setting_Game();
            setting_Game.Show();
        }

        private void btn_GamePage_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_Player admin_Player = new Admin_Player();
            admin_Player.Show();
        }
    }
}
