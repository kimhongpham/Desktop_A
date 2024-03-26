using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Drawing;
using System.Data.SqlClient;

namespace MEMORY_MATCH
{
    public partial class MainGame : Form
    {
        private MainGame maingame;
        private MainOption mainoption;
        private bool isPaused;
        public int score = 0;
        public int level = 1;
        private int rows = 2;
        private int cols = 3;
        private int DefaultCardSize = 300;
        private int CardWidth = 0;

        private const int HideCardsDelay = 1000;
        private int imgIndex;
        private List<PictureBox> cards;
        private PictureBox firstCard;
        private int matchedCardsCount;
        //static string basePath = "Properties.Resources";

        // list các hình ảnh
        private List<Image> imagePaths = new List<Image>
        {
            Properties.Resources.card1,
Properties.Resources.card2,
Properties.Resources.card3,
Properties.Resources.card4,
Properties.Resources.card5,
Properties.Resources.card6,
Properties.Resources.card7,
Properties.Resources.card8,
Properties.Resources.card9,
Properties.Resources.card10
            // Add paths to other images here
        };

        // Nút Pause
        private void btn_pause_Click(object sender, EventArgs e)
        {
            Pause pause = new Pause(maingame,_username);
            pause.Show();
            isPaused = !isPaused;
        }
        private void btn_setting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
            isPaused = !isPaused;
        }
        //private MainOption mainoption;
        private string _username;
        public MainGame(string username)
        {
            InitializeComponent();
            //score = 0;
            InitializeGame();
            _username = username;
        }
        public int GetUserId(string username)
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


        public void InsertGameSession()
        {
            DateTime date = DateTime.Now;
            DateTime currentDate = DateTime.Now;
            int userId = GetUserId(_username);
            int gameId = 1;
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
                string currentDateString = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

                // Insert new GameSession row with incremented GameSessionID
                query = "INSERT INTO GameSessions (GameSessionID, GameID, UserID, StartDate, EndDate, Score) VALUES (@gameSessionID, @gameId, @userId, @startDate, @endDate, @score)";
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@gameSessionID", maxGameSessionID + 1);
                command.Parameters.AddWithValue("@gameId", gameId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@startDate", dateString);
                command.Parameters.AddWithValue("@endDate", currentDateString);
                command.Parameters.AddWithValue("@score", score);

                command.ExecuteNonQuery();
            }
        }


        // Tạo Card
        public void InitializeGame()
        {

            //UpdateLevelScore(); // Khởi tạo điểm ban đầu
            Controls.Add(panel_level);
            Controls.Add(panel_score);
            Controls.Add(panel_times);
            Controls.Add(btn_setting);
            Controls.Add(btn_pause);
            label1.Text = "Level: \n  " + level.ToString();
            flipsCount = 0;
            maxFlips = GetMaxFlipsForLevel(level); // Set maxFlips for the current level
            // add Flips
            lbl_time.Text = $"Times: {maxFlips}";


            cards = new List<PictureBox>();
            matchedCardsCount = 0;
            // Tạo card bằng số hàng nhân số cột(2 card giống nhau)
            int cardCount = rows * cols;
            CardWidth = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DefaultCardSize / cols)));
            for (int i = 0; i < cardCount / 2; i++)
            {

                cards.Add(CreateCard(i));
                cards.Add(CreateCard(i));

            }

            ShuffleCards();


            // Add the cards to the form
            int cardIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int x = ((cardIndex % cols) * (CardWidth + 10)) + 160;
                    int y = ((cardIndex / cols) * (CardWidth + 10)) + 110;

                    PictureBox card = cards[cardIndex];
                    card.Location = new Point(x, y);
                    card.SizeMode = PictureBoxSizeMode.StretchImage;
                    card.BorderStyle = BorderStyle.FixedSingle;
                    card.Click += Card_Click;
                    Controls.Add(card);
                    card.BringToFront();
                    cardIndex++;

                }
            }

        }

        // hàm tạo card item
        private PictureBox CreateCard(int imageIndex)
        {
            int imageSize = DefaultCardSize / rows; // Kích thước hình ảnh cho mỗi ô lưới
            int imageCount = rows * cols; // Tổng số hình ảnh trong lưới
            PictureBox card = new PictureBox();
            card.Size = new Size(CardWidth, CardWidth);
            card.Tag = imageIndex;
            card.SizeMode = PictureBoxSizeMode.StretchImage;
            //string imagePath = imagePaths[imageIndex];
            Image img = Properties.Resources.imagecard2; 
            card.Image = ResizeImageToGrid(img, imageSize, imageSize);
            return card;
        }

        // hàm xáo trộn các thẻ hình
        private void ShuffleCards()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                PictureBox value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        // hàm thay đổi kích thước hình ảnh để phù hợp với form
        private Image ResizeImageToGrid(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        // hàm xủ lí click thẻ hình 
        private bool isProcessing = false; // Biến kiểm tra xem có đang xử lý các click trước đó hay không

        // Tạo số lần lật tối đa cho 3 level
        private int maxFlipsLevel1 = 5;
        private int maxFlipsLevel2 = 15;
        private int maxFlipsLevel3 = 25;
        private int flipsCount;
        private int maxFlips;
        
        //Phương thức lấy số lần lật cho level hiện tại
        private int GetMaxFlipsForLevel(int currentLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    return maxFlipsLevel1;
                case 2:
                    return maxFlipsLevel2;
                case 3:
                    return maxFlipsLevel3;
                default:
                    return maxFlipsLevel1; // Default to level 1 if level is not recognized
            }

        }
        private void Card_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                // Nếu đang xử lý các click trước đó, bỏ qua click hiện tại
                return;
            }

            PictureBox currentCard = (PictureBox)sender;
            int imageIndex = (int)currentCard.Tag;
            currentCard.Image = imagePaths[imageIndex];
            // lấy hình ảnh để hiện thị click

            if (firstCard == null)
            {
                firstCard = currentCard;
                flipsCount++;
            }
            else
            {
                if (firstCard == currentCard)
                {
                    // Đã chọn cùng 1 thẻ, không làm gì
                    return;
                }

                if (firstCard.Tag.ToString() == currentCard.Tag.ToString())
                {
                    // Hai hình giống nhau
                    isProcessing = true; // Đánh dấu đang xử lý

                    // Giảm 1 Flips
                    maxFlips--;
                    lbl_time.Text = "Times " + maxFlips.ToString();
                    // Cộng điểm
                    score += 100;
                    label2.Text = "Score: " + score.ToString();

                    Timer timer = new Timer();
                    timer.Interval = 10;
                    int steps = 20;
                    double opacityStep = 1.0 / steps;
                    int delay = 300 / steps;
                    int currentStep = 0;

                    timer.Tick += (s, args) =>
                    {
                        currentStep++;
                        if (currentStep <= steps)
                        {
                            double opacity = 1 - (opacityStep * currentStep);
                            currentCard.BackColor = Color.FromArgb((int)(opacity * 255), currentCard.BackColor);
                            firstCard.BackColor = Color.FromArgb((int)(opacity * 255), firstCard.BackColor);
                        }
                        else
                        {
                            currentCard.Visible = false;
                            firstCard.Visible = false;
                            timer.Stop();

                            firstCard = null;

                            matchedCardsCount += 2;
                            if (matchedCardsCount == cards.Count)
                            {
                                // Tất cả các thẻ đã khớp, chuyển sang level tiếp theo hoặc kết thúc trò chơi
                                if (level < 3) // Level tối đa
                                {
                                    level++;
                                    label1.Text = "Level: \n  "+level.ToString();
                                    rows++;
                                    cols++;
                                    Controls.Clear();
                                    InitializeGame();
                                }
                                else
                                {
                                    EndGame endgame = new EndGame(maingame,_username);
                                    endgame.Show();
                                }
                            }
                            // Tăng điểm và cập nhật label điểm
                            //UpdateLevelScore();
                            InsertGameSession();


                            isProcessing = false; // Đánh dấu kết thúc xử lý
                        }

                    };

                timer.Start();
                }
                else
                {
                    // Hai hình không khớp
                    isProcessing = true; // Đánh dấu đang xử lý

                    // Decrease maxFlips by 1 for each flip
                    maxFlips--;
                    lbl_time.Text = "Times: " + maxFlips.ToString();
                    currentCard.Enabled = false;
                    Timer timer = new Timer();
                    timer.Interval = 500;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        currentCard.Image = Properties.Resources.imagecard2;
                        firstCard.Image = Properties.Resources.imagecard2;
                        firstCard = null;
                        currentCard.Enabled = true;

                        isProcessing = false; // Đánh dấu kết thúc xử lý
                    };
                timer.Start();
                }
            }
                // Check if maxFlips becomes zero after decrement, trigger game over
                if (maxFlips <= 0)
                {
                    GameOver gameOver = new GameOver(maingame,_username);
                    gameOver.Show();
                    lbl_time.Text = "Times: 0";
                    return;
                }
        }
        //ResetGame
        public void ResetGame()
        {
            // Reset game state
            level = 1;
            score = 0;
            rows = 2;
            cols = 3;

            // Clear controls and initialize the game again
            Controls.Clear();
            InitializeGame();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            isPaused = false;
            InsertGameSession();
        }
    }
}
