using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace MEMORY_MATCH
{
    public partial class EndGame : Form
    {
        private MainGame maingame;
        private string _username;
        public EndGame(MainGame maingame, string username)
        {
            InitializeComponent();
            _username = username;
            this.maingame = maingame;
        }

        private void btn_mainoption_Click(object sender, EventArgs e)
        {
            this.Close();
            maingame.Close();
        }

        private void EndGame_Load(object sender, EventArgs e)
        {
            label2.Text = "Score: " + maingame.score;
            label3.Text = "Level: " + maingame.level;
            //maingame.InsertGameSession();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Close();
            PlayAgain playagain = new PlayAgain(maingame,_username);
            playagain.Show();
        }
        
    }
}
