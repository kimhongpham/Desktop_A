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
    public partial class Play : Form
    {
        private string _username;
        public Play(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void btn_no_play_Click(object sender, EventArgs e)
        {
            MainGame maingame= new MainGame(_username);
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
