using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codecool.Quest
{
    public partial class Choose : Form
    {
        private string _username;
        public Choose()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Choose_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private MainForm Mainform;
        public void btnRestart_Click(object sender, EventArgs e)
        {
            if (Mainform != null)
            {
                Mainform.FormClosed -= MainForm_FormClosed;
                Mainform.Close();
            }
            Mainform = new MainForm(_username);
            Mainform.FormClosed += MainForm_FormClosed;
            Mainform.Show();
            this.Close();
        }
        public void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mainform = null;
        }
    }
}
