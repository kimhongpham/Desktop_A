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
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
        }

        private void Instruction_Load(object sender, EventArgs e)
        {
            label1.Text = "Di chuyển nhân vật bằng mũi tên, vượt qua các chướng ngại vật để khám phá một số cơ sở của UEH";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}