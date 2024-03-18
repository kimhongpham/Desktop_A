using Codecool.Quest;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Quest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace quizGame
{
    public partial class Question : Form
    {

        // variables list for this quiz game
        int i;
        List<CauHoiBus> list = CauHoiBus.LayDSCauHoi(1);

        public Question()

        {
            InitializeComponent();
        }

        public void ClickAnswerEvent(object sender, EventArgs e)
        {
            if ((rad_A.Checked & list[i].dapan == list[i].dapan1) || (rad_B.Checked & list[i].dapan == list[i].dapan2) || (rad_C.Checked & list[i].dapan == list[i].dapan3) || (rad_D.Checked & list[i].dapan == list[i].dapan4))
            {
                QuestGame.x.diem++;
                QuestGame.x.mang += 1;                
                MessageBox.Show("bạn trả lời đúng rồi");
            }
            else
            {
                MessageBox.Show("bạn trả lời sai rồi");
            }
            this.Close();
        }
            public void lblQuestion_Click(object sender, EventArgs e)
        {

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            i = rd.Next(0, list.Count);
            lblQuestion.Text = list[i].noidung;
            rad_A.Text = list[i].dapan1;
            rad_B.Text = list[i].dapan2;
            rad_C.Text = list[i].dapan3;
            rad_D.Text = list[i].dapan4;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMon.Items.Count <= 0)
            {
                List<MonBus> list = MonBus.LayDSMon();
                foreach (MonBus item in list)
                {
                    comboBoxMon.Items.Add(item);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Question_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuestGame.x.mang--;
        }

        private void rad_A_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
