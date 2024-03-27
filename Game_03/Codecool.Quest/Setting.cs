using Codecool.Quest.Models.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codecool.Quest
{
    public partial class Setting : Form
    {
        private string _username;
        public Setting()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home formHome = new Home();
            formHome.TopMost = true;
            formHome.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(btnPause.Text=="Start")
            {
                MessageBox.Show("Bạn đang tạm ngừng chơi game");
            }
            if (btnPause.Text == "Stop")
            {
                this.Close();
            }

        }
        public event EventHandler PauseButtonClicked;
        public void btnPause_Click (object sender, EventArgs e)
        {
            PauseButtonClicked?.Invoke(sender, e);
            btnPause.Text = btnPause.Text == "Start" ? "Stop" : "Start";

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

        private void Setting_Load(object sender, EventArgs e)
        {

        }
        public event EventHandler RecordButtonClicked;
        public void btnRecord_Click(object sender, EventArgs e)
        {
            RecordButtonClicked?.Invoke(sender, e);
            btnRecord.Text = btnRecord.Text == "Record" ? "Close Record" : "Record"; ;
        }
    }
}
