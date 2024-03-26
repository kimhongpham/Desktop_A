using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MEMORY_MATCH
{
    public partial class PlayAgain : Form
    {
        private MainGame maingame;
        private string _username;
        public PlayAgain(MainGame maingame, string username)
        {
            InitializeComponent();
            _username = username;
            this.maingame = maingame;
        }

        private void btn_no_playagain_Click(object sender, EventArgs e)
        {
            this.Close();
            maingame.Close();
        }

        private void btn_yes_playagain_Click(object sender, EventArgs e)
        {
            this.Close();
            maingame.Close();
            MainGame mg=new MainGame(_username);
            mg.Show();
        }

        private void btn_exit_playagain_Click(object sender, EventArgs e)
        {

        }
    }
}
