using Codecool.Quest.Models;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System;
using WMPLib;
using System.IO;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Codecool.Quest.Models.Actors;
using System.Runtime.Remoting.Messaging;
using System.Timers;
using quizGame;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace Codecool.Quest {
    [Serializable]
    public partial class MainForm : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        GameMap map = MapLoader.LoadMap(@"\Resources\CSB.txt");
        int mapNumber = 0;
        Thread th = null;
        Thread th2 = null;

        public void StartNewThreads()
        {
            th = new Thread(() =>
            {
                int i = 0;
                bool isRunning = true;
                while (isRunning)
                {
                    Thread.Sleep(100);
                    if (map.mapChanging)
                    {
                        int tempHealth = map.Player.Health;
                        mapNumber = map.num;
                        string currentLevel = map.changeMapLevel(mapNumber);
                        map = MapLoader.LoadMap(currentLevel);
                        map.mapChanging = false;
                        map.Player.Health = tempHealth;

                    }
                    if (!this.Disposing)
                    {
                        try
                        {
                            Invoke((Action)(() => Refresh()));
                        }
                        catch (Exception ex)
                        {
                            var x = this;
                            isRunning = false;
                        }
                    }
                }
            });
            th2 = new Thread(() =>
                {
                    while (true)
                    {
                        // map.MoveMobs();
                        global::System.Threading.ThreadState state = th2.ThreadState;
                        if (state == global::System.Threading.ThreadState.AbortRequested)
                        {
                            break;
                        }
                    }
                });

            th.Start();
            th2.Start();
        }

        private string _username;
        public MainForm(string username)
        {

            InitializeComponent();
            Launch();
            _username = username; // đặt trường riêng tư thành tên người dùng
            lbl_Username.Text = _username;
            RecordtoolStripMenuItem2.Click += toolStripMenuItem2_Click;
            StoptoolStripMenuItem3.Click += toolStripMenuItem3_Click; // Đăng ký sự kiện 'Click' cho 'pauseToolStripMenuItem'
        }


        public void Launch()
        {
            Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (th.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        map.Player.Move(-1, 0);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                    case Keys.Up:
                        map.Player.Move(0, -1);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                    case Keys.Right:
                        map.Player.Move(1, 0);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                    case Keys.Down:
                        map.Player.Move(0, 1);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                }

            }
        }


        private DateTime startDate;
        private DateTime endDate;

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            startDate = DateTime.Now; // capture startDate

            QuestGame.x = new nguoichoi();
            lblGameOver.Visible = false;
            textBoxRecord.Visible = false;
            string filePath = @".\Resources\legends-never-die-against-the-current-cktg-2017-nhacchuongviet.com.wav";
            soundPlayer1.SoundLocation = filePath;
            soundPlayer1.Play();

            Home FormHome = new Home();
            FormHome.TopMost = true; // Đặt form 2 ở trên cùng
            FormHome.Show();
        }
        public bool isRecordWritten = false;
        private int GetUserId(string username)
        {
            int userId = -1;

            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();
                string query = "SELECT UserID FROM Users WHERE UserName = @username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@username", username);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(0);
                    }
                }
            }

            return userId;
        }

        public void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            int Score = 0;

            if (timeSpan < TimeSpan.FromSeconds(30))
            {
                Score = QuestGame.x.diem +3;
            }
            else if (timeSpan < TimeSpan.FromMinutes(1))
            {
                Score = QuestGame.x.diem + 2;
            }
            else if (timeSpan < TimeSpan.FromMinutes(2))
            {
                Score = QuestGame.x.diem + 1;
            }
            else if (timeSpan < TimeSpan.FromMinutes(3))
            {
                Score = QuestGame.x.diem + 0;
            }
            else
            {
                map.Player.Health = 0;
            }

            endDate = DateTime.Now; // record endDate

            DateTime date = DateTime.Now;
            int userId = GetUserId(_username);
            int gameId = 3;
            Inventory inventory = map.inventory;
            Dictionary<string, Tiles.Tile> tiles = new Dictionary<string, Tiles.Tile>();
            tiles = Tiles.tileMap;
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            Label[] labels = { label2, label3, label4, label5, label6, label7, label8, label9 };
            lnlHealth.Text = "Health " + map.Player.Health.ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = map.Player.maxHealth;
            if (map.Player.Health <= 0)
            {
                map.Player.Health = 0;
                map.Player.isAlive = false;
                lblGameOver.Visible = true;
                timer1.Stop();
                stopwatch.Stop();
                Choose choose = new Choose();
                choose.TopMost = true; // Đặt form 2 ở trên cùng
                choose.Show();
                MessageBox.Show("Bạn đã thua cuộc");


                /*              if (!isRecordWritten)
                              {
                                  using (StreamWriter file = new StreamWriter(@".\Resources\kyluc.txt", true))
                                  {
                                      file.WriteLine("GameSession\nGameID\nUser\nStartDate\nEndDate\nScore");
                                      file.WriteLine("End\nNull\nNull+\n" + currentDate.ToShortDateString()+"\n"+ currentDate.ToShortDateString()+Score);
                                  }

                                  isRecordWritten = true;
                              }*/


                using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                {
                    sqlConnection.Open();
                    // Get max GameSessionID
                    int maxGameSessionID = 0;
                    string query = "SELECT MAX(GameSessionID) FROM GameSessions";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        maxGameSessionID = reader.GetInt32(0);
                    }
                    reader.Close();

                    // Format the startDate and endDate
                    string dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
                    string endDateString = endDate.ToString("yyyy-MM-dd HH:mm:ss");

                    // Insert new GameSession row with incremented GameSessionID
                    query = "INSERT INTO GameSessions (GameSessionID, GameID, UserID, StartDate, EndDate, Score) VALUES (@gameSessionID, @gameId, @userId, @startDate, @endDate, @score)";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@gameSessionID", maxGameSessionID + 1);
                    command.Parameters.AddWithValue("@gameId", gameId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@startDate", dateString);
                    command.Parameters.AddWithValue("@endDate", endDateString);
                    command.Parameters.AddWithValue("@score", Score);

                    command.ExecuteNonQuery();
                }
                th.Abort();
                th2.Abort();
            }
            if (map.Player.gameWin)
            {
                label15.Text = "Chúc mừng bạn đã chiến thắng" + "\nTime: " 
                    + lblTime.Text + "\nScore: " + Convert.ToString(Score)
                    + "start'time: " + date.ToString("hh\\:mm\\:ss");
                map.Player.isAlive = true;
                label15.Visible = true;
                timer1.Stop();
                stopwatch.Stop();
                Choose choose = new Choose();
                choose.TopMost = true; // Đặt form 2 ở trên cùng
                choose.Show();

                /*             if (!isRecordWritten)
                             {
                                 using (StreamWriter file = new StreamWriter(@".\Resources\kyluc.txt", true))
                                 {
                                     file.WriteLine("GameSession\nGameID\nUser\nStartDate\nEndDate\nScore");
                                     file.WriteLine("");
                                 }

                                 isRecordWritten = true;
                             }*/
                using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                {
                    sqlConnection.Open();
                    // Get max GameSessionID
                    int maxGameSessionID = 0;
                    string query = "SELECT MAX(GameSessionID) FROM GameSessions";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        maxGameSessionID = reader.GetInt32(0);
                    }
                    reader.Close();

                    // Format the startDate and endDate
                    string dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
                    string endDateString = endDate.ToString("yyyy-MM-dd HH:mm:ss");

                    // Insert new GameSession row with incremented GameSessionID
                    query = "INSERT INTO GameSessions (GameSessionID, GameID, UserID, StartDate, EndDate, Score) VALUES (@gameSessionID, @gameId, @userId, @startDate, @endDate, @score)";
                    command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@gameSessionID", maxGameSessionID + 1);
                    command.Parameters.AddWithValue("@gameId", gameId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@startDate", dateString);
                    command.Parameters.AddWithValue("@endDate", endDateString);
                    command.Parameters.AddWithValue("@score", Score);

                    command.ExecuteNonQuery();
                }
                th2.Abort();
                th.Abort();

            }
            progressBar1.Value = map.Player.Health;
            int i = 0;
            foreach(KeyValuePair<string, int> pair in inventory.playerInventory)
            {
                Image image = tiles[pair.Key].bitmap;
                boxes[i].Width = 48;
                boxes[i].Height = 48;
                boxes[i].Image = image;
                
                labels[i].Text = " x " + pair.Value.ToString();
                labels[i].Visible = true;
                i++;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    Cell cell = map.GetCell(x, y);
                    if (cell.Actor != null)
                    {
                        Tiles.DrawTile(e.Graphics, cell.Actor, x, y);
                    }
                    else
                    {
                        Tiles.DrawTile(e.Graphics, cell, x, y);
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, System.EventArgs e)
        {

        }

        private void label10_Click(object sender, System.EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        public void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Lưu trạng thái vào Properties.Settings
            Properties.Settings.Default.AppState = "Trạng thái cần lưu";
            Properties.Settings.Default.Save();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {


            stopwatch.Start();
            timer1.Start();
            label10.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            StartNewThreads();
            this.Focus();
            this.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home FormHome = new Home();
            FormHome.TopMost = true;
            FormHome.ShowDialog();
        }

        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.TopMost = true;
            instruction.ShowDialog();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.RecordButtonClicked += toolStripMenuItem2_Click;
            setting.PauseButtonClicked += toolStripMenuItem3_Click; // Đăng ký phương thức xử lý sự kiện PauseButtonClicked
            setting.TopMost = true;
            setting.ShowDialog();
        }


        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit exit = new Exit();
            exit.TopMost = true;
            exit.ShowDialog();
        }


        private SoundPlayer soundPlayer1 = new SoundPlayer();
        bool isSoundPlaying = true; // Biến theo dõi trạng thái âm thanh
        private void turnOnTurnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

                if (isSoundPlaying)
                {
                    soundPlayer1.Stop(); // Tắt âm thanh
                    isSoundPlaying = false;
                    Console.WriteLine("Đã tắt âm thanh.");
                }
                else
                {
                    soundPlayer1.Play(); // Bật âm thanh
                    isSoundPlaying = true;
                    Console.WriteLine("Đã bật âm thanh.");
                }

        }

        private void lengToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundPlayer1.Stop();
                string filePath = @".\Resources\legends-never-die-against-the-current-cktg-2017-nhacchuongviet.com.wav";

                try
                {
                    SoundPlayer soundPlayer = new SoundPlayer(filePath);
                    soundPlayer.Play();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Tệp âm thanh không tồn tại.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                }
        }

        private void marioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundPlayer1.Stop();
            string filePath = @".\Resources\game-mario-nhacchuongviet.com_1.wav";

            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(filePath);
                soundPlayer.Play();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Tệp âm thanh không tồn tại.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

       
        private void lblTime_Click(object sender, EventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            string Time = timeSpan.ToString(@"hh\:mm\:ss");
            lblTime.Text = Time;
            lblScore.Text = Convert.ToString(QuestGame.x.diem);
            if (QuestGame.x.mang == 2)
            {
                map.Player.Health = 2;
            }
            else if (QuestGame.x.mang == 1)
            {
                map.Player.Health = 1;
            }
            else if (QuestGame.x.mang == 0)
            {
                map.Player.Health = 0;
                lblGameOver.Visible = true;
                timer1.Stop();
            }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.RecordButtonClicked += toolStripMenuItem2_Click;
            setting.PauseButtonClicked += toolStripMenuItem3_Click; // Đăng ký phương thức xử lý sự kiện PauseButtonClicked
            setting.TopMost = true;
            setting.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                
            }
            else
            {
                stopwatch.Start();
            }
            timer1.Enabled = !timer1.Enabled;
            StoptoolStripMenuItem3.Text = StoptoolStripMenuItem3.Text == "Start" ? "Stop" : "Start";

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if ( RecordtoolStripMenuItem2.Text == "Close Record" )
            { textBoxRecord.Visible = true;
                string filePath = @".\Resources\kyluc.txt"; // Thay đổi đường dẫn tệp tin tại đây
                try
                {
                    if (File.Exists(filePath))
                    {
                        string show = File.ReadAllText(filePath);
                        textBoxRecord.Text = show;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tệp tin kyluc.txt");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc tệp tin: " + ex.Message);
                } }
            else
            { textBoxRecord.Visible=false; }    

            RecordtoolStripMenuItem2.Text = RecordtoolStripMenuItem2.Text == "Record" ? "Close Record" : "Record";
        }

        private void HometoolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void countinueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khôi phục trạng thái từ Properties.Settings
            string appState = Properties.Settings.Default.AppState;
            // Sử dụng trạng thái để thực hiện các hành động phù hợp
        }

        private void textBoxRecord_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
