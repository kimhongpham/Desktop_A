using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMORY_MATCH
{
    public partial class Exit : Form
    {
        private MainOption mainoption;
        private MainGame maingame;
        //private bool mainGameWasVisible;
        public Exit(MainOption mainoption, MainGame maingame)
        {
            InitializeComponent();
            this.mainoption = mainoption;
            this.maingame = maingame;
            //// Lưu trạng thái của maingame trước khi ẩn nó
            //if (maingame != null)
            //{
            //    mainGameWasVisible = maingame.Visible;
            //}
        }

        private void btn_yes_exit_Click(object sender, EventArgs e)
        {
            // Gọi phương thức SaveGameState() từ MainGame trước khi đóng trò chơi
            if (maingame != null)
            {
                maingame.SaveGameState();
            }
            if (maingame != null && maingame.Visible)
            {
                maingame.Hide();
            }
            if (mainoption != null && mainoption.Visible)
            {
                mainoption.Hide();
            }
            
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_no_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Exit_Load(object sender, EventArgs e)
        {
            //maingame.SaveGameState();
            //// Lưu trạng thái của maingame trước khi ẩn nó
            //if (maingame != null)
            //{
            //    mainGameWasVisible = maingame.Visible;
            //}
        }
        //public bool MainGameWasVisible
        //{
        //    get { return mainGameWasVisible; }
        //}

        
    }
}
    