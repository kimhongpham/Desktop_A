using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMORY_MATCH
{
    public partial class PlayAgain : Form
    {
        private MainGame maingame;
        public PlayAgain(MainGame maingame)
        {
            InitializeComponent();
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
            MainGame mg=new MainGame();
            mg.Show();
        }

        private void btn_exit_playagain_Click(object sender, EventArgs e)
        {

        }
    }
}
