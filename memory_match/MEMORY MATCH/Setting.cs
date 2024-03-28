using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;

namespace MEMORY_MATCH
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            // Load the saved setting for the radio button
            bool isSoundOn = Properties.Settings.Default.SoundOn;
            if (isSoundOn)
            {
                rdb_on.Checked = true;
                BackgroundSound.PlayMusic(Properties.Resources.nhacnen1);
            }
            else
            {
                rdb_off.Checked = true;
            }
        }

        private void btn_exit_setting_Click(object sender, EventArgs e)
        {
            EventClick();
            // Save the state of the radio button before closing the form
            Properties.Settings.Default.SoundOn = rdb_on.Checked;
            Properties.Settings.Default.Save();
            Close();
            //if (maingame != null)
            //{
            //    maingame.SetButtonClickedStatus(false);
            //}

            //if (mainoption != null)
            //{
            //    mainoption.SetButtonClickedStatus(false);
            //}
        }
     
        private void rdb_on_CheckedChanged(object sender, EventArgs e)
        {
           
            try
            {
                if (rdb_on.Checked == true)
                {
                    BackgroundSound.PlayMusic(Properties.Resources.nhacnen1);
                    SoundManager.IsPlaying = true;
                } 
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private void rdb_off_CheckedChanged(object sender, EventArgs e)
        {
            if (SoundManager.Player != null && SoundManager.IsPlaying)
            {
                SoundManager.Player.Stop();
                SoundManager.IsPlaying = false;
            }
        }

        private void volumetrackbar_Scroll(object sender, ScrollEventArgs e)
        {
            // Lấy giá trị mới của scrollbar
            int volume = volumetrackbar.Value;

            BackgroundSound.ChangeVolume(volume);
        }
       private void EventClick()
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
