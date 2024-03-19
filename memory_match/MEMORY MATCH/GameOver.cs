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
    public partial class GameOver : Form
    {
        private MainGame maingame;
        public GameOver(MainGame maingame)
        {
            InitializeComponent();
            this.maingame = maingame;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Close();
            PlayAgain playagain = new PlayAgain(maingame);
            playagain.Show();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            label2.Text = "Score: " + maingame.score;
            label3.Text = "Level: " + maingame.level;
        }

        private void btn_mainoption_Click(object sender, EventArgs e)
        {
            maingame.Close();
            this.Close();
        }
    }
}
