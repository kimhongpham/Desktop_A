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
            // Lấy form MainForm hiện tại
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                // Đóng MainForm
                mainForm.Hide();
            }
            this.Hide();
        }
        private MainForm Mainform;

        public void btnRestart_Click(object sender, EventArgs e)
        {
            // Lấy form MainForm hiện tại
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                // Đóng MainForm
                mainForm.Hide();
            }
            this.Hide();
        }
        public void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mainform = null;
        }
    }
}
