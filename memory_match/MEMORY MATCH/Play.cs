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
    public partial class Play : Form
    {
        private MainGame maingame;
        private bool mainGameWasVisible;
        private Exit exit;
        public Play(MainGame maingame,Exit exit)
        {
            InitializeComponent();
            this.maingame = maingame;
            this.exit = exit;
            //// Lấy trạng thái của maingame từ form Exit
            //if (exit != null)
            //{
            //    mainGameWasVisible = exit.MainGameWasVisible;
            //}
        }

        private void btn_no_play_Click(object sender, EventArgs e)
        {
            MainGame maingame= new MainGame();
            maingame.Show();
            this.Hide();
        }

        private void btn_exit_play_Click(object sender, EventArgs e)
        {
            this.Hide ();
        }

        private void btn_yes_play_Click(object sender, EventArgs e)
        {
            //// Kiểm tra nếu maingame đã được khởi tạo và đang bị ẩn
            //if (maingame != null && !maingame.Visible)
            //{
            //    // Hiển thị lại maingame
            //    maingame.Show();
            //}
            //else
            //{
            //    MainGame game=new MainGame();
            //    game.Show();
            //}
            // Khôi phục trạng thái game

            // Khôi phục trạng thái trò chơi khi nhấn nút Yes
            MainGame mainGameForm = new MainGame();
            mainGameForm.RestoreGameState(); // Gọi phương thức khôi phục trạng thái trò chơi
            mainGameForm.Show(); // Hiển thị form MainGame


            this.Hide();
        }

    }
}
