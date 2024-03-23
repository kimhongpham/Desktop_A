using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codecool.Quest
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {

            Instruction instruction = new Instruction();
            instruction.TopMost = true;
            instruction.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit exitGame = new Exit();
            exitGame.TopMost = true;
            exitGame.Show();
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

        }
    }
}
