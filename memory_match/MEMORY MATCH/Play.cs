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
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
        }

        private void btn_no_play_Click(object sender, EventArgs e)
        {
            MainGame maingame= new MainGame();
            maingame.Show();
            this.Close();
        }

        private void btn_exit_play_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void btn_yes_play_Click(object sender, EventArgs e)
        {
        }
    }
}
