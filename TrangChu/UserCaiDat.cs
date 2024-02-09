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

namespace Gaming_Dashboard
{
    public partial class UserCaiDat : UserControl
    {
        private SoundManager sound = new SoundManager(@"D:\github_repo\Game-Dashboard-GabiBox\Resources\flyaway-music.mp3");
        public UserCaiDat()
        {
            InitializeComponent();
        }
        private static UserCaiDat _instance;
        public static UserCaiDat Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserCaiDat();
                return _instance;
            }
        }

        
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (guna2ToggleSwitch1.Checked)
            {
                sound.Play();
            }
            else
            {
                sound.Pause();
            }
        }
     //   UserMain a = new UserMain();    
        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void UserCaiDat_Load(object sender, EventArgs e)
        {
            sound.Stop();
        }
    }
}
