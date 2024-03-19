
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMORY_MATCH
{
    public partial class MainOption : Form
    {
        private MainGame maingame;
        private MainOption mainoption;
        // public TimeSpan ElapsedTime { get; private set; }

        public MainOption()
        {
            InitializeComponent();
            //BackgroundSound.PlayMusic();
        }

        //public SoundPlayer player;
        //public bool isPlaying = false;

        // Để chỉ được nhấn 1 lần ra 1 form
        private bool isButtonClicked = false;
        public void SetButtonClickedStatus(bool status)
        {
            isButtonClicked = status;
        }

        // Xử lý nút Howtoplay
        private void btn_howtoplay_Click(object sender, EventArgs e)
        {
            EventClick();
            if (!isButtonClicked)
            {
                isButtonClicked = true;
            }
            else
            {
                return; // Không có hiệu lực nếu đã click liên tiếp vào nút "btn_howtoplay"
            }
            Howtoplay btn_howtoplay = new Howtoplay(this);
            btn_howtoplay.Show();
        }

        // Xử lý nút Play
        private void btn_play_Click(object sender, EventArgs e)
        {
            EventClick();
            // this.Hide(); giúp tắt trang mainoption nhưng hiện đang bị lỗi
            Play play = new Play();
            play.Show();
        }

        // Xử lý nút Exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            EventClick();
            if (!isButtonClicked)
            {
                isButtonClicked = true;
            }
            else
            {
                return; // Không có hiệu lực nếu đã click liên tiếp 
            }
            Exit exit = new Exit();
            exit.Show();
        }

        //Xử lý nút Setting
        private void btn_setting_Click(object sender, EventArgs e)
        {
            EventClick();
            SoundManager.IsPlaying = true;
            Setting setting = new Setting();
            setting.Show();
        }

        // Xử lý nút Record
        //private SoundPlayer recordPlayer; // Thêm biến recordPlayer để quản lý âm thanh của nút btn_record
        private void btn_record_Click(object sender, EventArgs e)
        {
            EventClick();
            if (!isButtonClicked)
            {
                isButtonClicked = true;
            }
            else
            {
                return; // Không có hiệu lực nếu đã click liên tiếp 
            }
            Record record = new Record(this);
            record.Show();
        }

        // trình chạy MainOption
        private void MainOption_Load(object sender, EventArgs e)
        {
            try
            {
                SoundManager.Player = new SoundPlayer(Properties.Resources.nhacnen1);

                SoundManager.Player.Play();
                SoundManager.IsPlaying = true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        //Xử lý sự kiện click phát âm thanh khi click 1 nút
        public void EventClick()
        {
            SoundManager.Player = new SoundPlayer(Properties.Resources.click_button_140881);
            SoundManager.Player.PlaySync(); // Chờ phát nhạc "win" hoàn thành
            if (SoundManager.Player != null && SoundManager.IsPlaying)
            {
                SoundManager.Player = new SoundPlayer(Properties.Resources.nhacnen1);
                SoundManager.Player.Play(); // Phát nhạc "nhacnen1"
            }
            else
            {
                SoundManager.Player = new SoundPlayer(Properties.Resources.nhacnen1);
                SoundManager.Player.Stop();
                SoundManager.IsPlaying = false;
            }
        }
    }
}


