using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MEMORY_MATCH
{
    internal class BackgroundSound
    {
       static private WaveOutEvent waveOut;
        public static void ChangeVolume(int volume)
        {
            if (waveOut != null)
            {
                // Cập nhật giá trị âm lượng của WaveOutEvent
                waveOut.Volume = volume / 100f;
            }
        }
        public static void PlayMusic(object music)
        {
            SoundManager.Player = new SoundPlayer(Properties.Resources.nhacnen1);
            SoundManager.Player.Play();
            SoundManager.IsPlaying = true;
            // Dừng phát nhạc nếu đã có nhạc đang phát
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\nhacnen1.wav";
            //StopMusic();
            // Tạo đối tượng AudioFileReader từ filePath
            using (var audioFileReader = new AudioFileReader(filePath))
            {
                // Khởi tạo đối tượng WaveOutEvent
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFileReader);
                // Bắt đầu phát nhạc
                waveOut.Play();
            }
        }
        public static void StopMusic()
        {
            SoundManager.Player.Stop();
            SoundManager.IsPlaying = false;
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
        }
    }
}
