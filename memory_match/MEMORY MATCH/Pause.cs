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
    public partial class Pause : Form
    {
        private MainGame maingame;
        public Pause(MainGame mainGame)
        {
            InitializeComponent();
            this.maingame = mainGame;
        }
       
        private void btn_quit_pause_Click(object sender, EventArgs e)
        {
            this.Close();
            Exit exit = new Exit();
            exit.Show();
            // Lỗi Play chưa lưu được nên bị lặp lại nhiều lần. có thể phát triển thêm sau
            //// Kiểm tra nếu biến mainoption đã được khởi tạo
            //if (mainoption == null)
            //{
            //    // Khởi tạo biến mainoption nếu nó chưa được khởi tạo
            //    mainoption = new MainOption();
            //}

            //// Kiểm tra nếu form MainOption chưa bị dispose
            //if (!mainoption.IsDisposed)
            //{
            //    mainoption.Show(); // Hiển thị lại form MainOption
            //}
            //maingame.SetButtonClickedStatus(false);
        }

        private void btn_continue_pause_Click(object sender, EventArgs e)
        {
            Close();
            //maingame.SetButtonClickedStatus(false);
        }

        private void btn_playagain_pause_Click(object sender, EventArgs e)
        {
            this.Close ();
            PlayAgain playagain = new PlayAgain(maingame);
            playagain.Show();
        }
    }
}
