using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Game02
{
    public partial class Scoreboard : Form
    {
        private string _username;
        public Scoreboard(string username)
        {
            InitializeComponent();
            _username = username;

        }

        public string PlayerName { get; set; }
        public int ScoreValue { get; set; }

        public Scoreboard(string playerName, int scoreValue)
        {
            PlayerName = playerName;
            ScoreValue = scoreValue;
        }
    }
}
