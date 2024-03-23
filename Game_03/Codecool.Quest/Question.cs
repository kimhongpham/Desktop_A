using Codecool.Quest;
using Codecool.Quest.Models.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace quizGame
{
    public partial class Question : Form
    {

        // variables list for this quiz game
        private Random random = new Random();
        private string[,] questions = new string[,]
        {
        { "Cơ sở B của UEH tọa lạc tại quận nào?", "Quận 10", "quận 1", "quận 3" },
        { "Cơ sở N của UEH tọa lạc tại quận nào?", "Huyện Bình Chánh", "quận 1", "quận 3" },
        { "Cơ sở A của UEH tọa lạc tại quận nào?", "Quận 3", "quận 2", "quận 1" },
        { "Cơ sở B được mệnh danh là gì?", "cơ sở sáng tạo", "cơ sở hiện đại", "cơ sở năng động" },
        { "Cơ sở B được đưa vào sử dụng năm nào?", "2020", "2019", "2018" },
        { "Cơ sở N được đưa vào sử dụng năm nào?", "2021", "2019", "2018" },
        { "Cơ sở B có bao nhiêu tầng?", "19", "15", "17" },
        { "Cơ sở A có bao nhiêu tầng?", "6", "2", "3" },
        { "Cơ sở B được xây dựng theo mô hình nào?", "Đại học thông minh","Đại học sáng tạo", "Đại học xanh " },
        { "Cơ sở N được xây dựng theo mô hình nào?", "Đại học xanh","Đại học sáng tạo", "Đại học thông minh " },
        { "Gần Cơ sở B có ký túc xá cho sinh viên không?", "có", "Có nhưng chỉ dành cho sinh viên năm nhất", "Không" },
        { "Mục tiêu của việc xây dựng cơ sở B là gì?","Tất cả đều đúng", "Nâng cao chất lượng đào tạo", "Mở rộng quy mô đào tạo" },
        { "Cơ sở N gồm bao nhiêu khu vực?", "2", "1", "3" },
        { "Cơ sở B gồm bao nhiêu khu vực?", "2", "1", "3" },
        {"Đâu là cơ sở chính của UEH?","cơ sở A","cơ sở B", "cơ sở N"},
        {"UEH shuttle Bus thường đi qua giữa những cơ sở nào?","cơ sở A, cơ sở B, cơ sở N","cơ sở A, cơ sở H, cơ sở I","cơ sở A, cơ sở B, cơ sở I"},
        {"Cơ sở N của UEH có bao nhiêu tầng chứa thư viện?","2","3","1"},
        {"UEH có bao nhiêu cơ sở tất cả?","13","15","9"},
        {"Đâu là nơi hầu hết sinh viên UEH học thể chất?","cở sở N ","cơ sở A","cở sở B"},
        { "Năm thành lập đại học kinh tế TPHCM là?", "1976", "1988", "1967" }
        };

        public int index;
        public void AskQuestion()
        {
            index = random.Next(questions.GetLength(0));
            string question = questions[index, 0];
            string correctAnswer = questions[index, 1];
            string wrongAnswer1 = questions[index, 2];
            string wrongAnswer2 = questions[index, 3];

            // Hoán đổi vịtrí các câu trả lời ngẫu nhiên
            string[] answerOptions = new string[] { correctAnswer, wrongAnswer1, wrongAnswer2 };
            ShuffleArray(answerOptions);

            lblQuestion.Text = question;
            rad_A.Text = "A. " + answerOptions[0];
            rad_B.Text = "B. " + answerOptions[1];
            rad_C.Text = "C. " + answerOptions[2];
        }

        private void ShuffleArray<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = random.Next(n);
                n--;
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }


        public Question()

        {
            InitializeComponent();
        }

        public void ClickAnswerEvent(object sender, EventArgs e)
        {

            string correctAnswer = questions[index, 1];
            string selectedAnswer = GetSelectedAnswer();

            if (selectedAnswer == correctAnswer)
            {
                QuestGame.x.diem++;
                QuestGame.x.mang += 1;
                MessageBox.Show("Bạn trả lời đúng rồi!");
            }
            else
            {
                MessageBox.Show("Bạn trả lời sai rồi!");
            }
            AskQuestion();
            this.Close();
        }

        private string GetSelectedAnswer()
        {
            if (rad_A.Checked)
            {
                return rad_A.Text.Substring(3); // Xóa tiền tố "A. " để lấy đáp án
            }
            else if (rad_B.Checked)
            {
                return rad_B.Text.Substring(3); // Xóa tiền tố "B. " để lấy đáp án
            }
            else if (rad_C.Checked)
            {
                return rad_C.Text.Substring(3); // Xóa tiền tố "C. " để lấy đáp án
            }
            else
            {
                return string.Empty; // Không có đáp án nào được chọn
            }
        }
        public void lblQuestion_Click(object sender, EventArgs e)
        {

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            AskQuestion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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