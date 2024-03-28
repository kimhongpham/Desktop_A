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
using System.Data.SqlClient;


using System.Drawing;
using Newtonsoft.Json;
using admin___tke;

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
        private List<Point> cardPositions;
        private List<Size> cardSizes;

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
            Pause pause = new Pause(maingame,mainoption);
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
        public MainGame()
        {
            InitializeComponent();
            //score = 0;
            cardPositions = new List<Point>();
            cardSizes = new List<Size>();
            //_username = username; // đặt trường riêng tư thành tên người dùng

            InitializeGame();
            // Khởi tạo đối tượng maingame
            maingame = this; // Gán đối tượng hiện tại cho maingame

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
            //maxFlips = GetMaxFlipsForLevel(level); // Set maxFlips for the current level
            //// add Flips
            //lbl_time.Text = "Times:    "+ maxFlips;
            // Chỉ gán giá trị mới cho maxFlips nếu nó chưa được gán từ dữ liệu khôi phục
            if (maxFlips == 0)
            {
                maxFlips = GetMaxFlipsForLevel(level); // Set maxFlips for the current level
                                                       // add Flips
                lbl_time.Text = "Times:    " + maxFlips;
            }


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
                    if (cardIndex < cards.Count) // Kiểm tra xem cardIndex có nhỏ hơn kích thước của danh sách cards hay không
                    {
                        int x = ((cardIndex % cols) * (CardWidth + 10)) + 160;
                        int y = ((cardIndex / cols) * (CardWidth + 10)) + 110;
                        // Tạo thẻ mới và thêm vào danh sách
                        PictureBox card = cards[cardIndex];
                        // Sau khi thêm thẻ vào form
                        Point cardLocation = new Point(x, y);
                        Size cardSize = new Size(CardWidth, CardWidth);
                        cardPositions.Add(cardLocation);
                        cardSizes.Add(cardSize);
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

            // Lấy thẻ hình ảnh hiện tại được click
            PictureBox currentCard = (PictureBox)sender;
            int imageIndex = (int)currentCard.Tag;      //Lấy chỉ số của hình ảnh tương ứng
            currentCard.Image = imagePaths[imageIndex]; //Hiển thị hình ảnh tương ứng với thẻ được click

            // Nếu đây là lần click đầu tiên trên một cặp thẻ thì lưu thẻ hiện tại là thẻ đầu tiên và tăng flips lên 1
            if (firstCard == null)
            {
                firstCard = currentCard;
                flipsCount++;
            }
            else //Nêú không phải lượt click đầu tiên của 1 cặp thẻ
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
                    // Tạo và khởi động một timer để thực hiện các hiệu ứng khi hai hình giống nhau
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
                        {   //Ẩn các thẻ sau khi hoàn thành hiệu ứng.
                            currentCard.Visible = false;
                            firstCard.Visible = false;
                            timer.Stop();
                            //Đặt lại thẻ đầu tiên là null
                            firstCard = null;
                            matchedCardsCount += 2; //Tăng số lượng các thẻ đã khớp lên 2
                            // Kiểm tra đã khớp tất cả các thẻ chưa
                            if (matchedCardsCount == cards.Count)
                            {
                                // Nếu tất cả các thẻ đã khớp, chuyển sang level tiếp theo hoặc kết thúc trò chơi
                                if (level < 3) // Level tối đa là 3
                                {
                                    level++;
                                    label1.Text = "Level: \n  " + level.ToString();
                                    rows++;
                                    cols++;
                                    Controls.Clear();
                                    InitializeGame();
                                }
                                else
                                {
                                    EndGame endgame = new EndGame(this);
                                    endgame.Show();
                                }
                            }
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
                    currentCard.Enabled = false; // Tạm thời vô hiệu hóa thẻ hiện tại để không cho người dùng lật thêm thẻ khác
                    Timer timer = new Timer();   // Tạo và khởi động một timer để ẩn hai thẻ không khớp sau một khoảng thời gian
                    timer.Interval = 500;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        // Đặt lại hình ảnh của hai thẻ về mặt sau
                        currentCard.Image = Properties.Resources.imagecard2;
                        firstCard.Image = Properties.Resources.imagecard2;
                        firstCard = null;           // Đặt thẻ đầu tiên về null
                        currentCard.Enabled = true; // Kích hoạt lại thẻ hiện tại để người dùng có thể lật lại
                        isProcessing = false; // Đánh dấu kết thúc xử lý
                    };
                    timer.Start();  // Bắt đầu timer để thực hiện việc ẩn hai thẻ không khớp
                }
            }
            // Check if maxFlips becomes zero after decrement, trigger game over
            if (maxFlips < 0)
            {
                GameOver gameOver = new GameOver(this);
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
        // Phương thức để lưu trạng thái game vào cơ sở dữ liệu
        public void SaveGameState()
        {
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();
                // Xóa dữ liệu cũ nếu có
                string deleteQuery = "DELETE FROM GameState";
                using (SqlCommand command = new SqlCommand(deleteQuery, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }

                // Thêm dữ liệu mới
                string insertQuery = "INSERT INTO GameState (Level, Score, Rows, Cols, MaxFlips) VALUES (@Level, @Score, @Rows, @Cols, @MaxFlips)";
                // Thực thi truy vấn và truyền các tham số
                using (SqlCommand command = new SqlCommand(insertQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@Score", score);
                    command.Parameters.AddWithValue("@Rows", rows);
                    command.Parameters.AddWithValue("@Cols", cols);
                    command.Parameters.AddWithValue("@MaxFlips", maxFlips);
                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        // Phương thức để khôi phục trạng thái game từ cơ sở dữ liệu
        public void RestoreGameState()
        {
            // Xóa các PictureBox đã được tạo ra từ trước
            foreach (PictureBox card in cards)
            {
                Controls.Remove(card);
            }
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();
                string selectQuery = "SELECT TOP 1 Level, Score, Rows, Cols, MaxFlips FROM GameState ORDER BY ID DESC";
                using (SqlCommand command = new SqlCommand(selectQuery, sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        level = Convert.ToInt32(reader["Level"]);
                        score = Convert.ToInt32(reader["Score"]);
                        rows = Convert.ToInt32(reader["Rows"]);
                        cols = Convert.ToInt32(reader["Cols"]);
                        maxFlips = Convert.ToInt32(reader["MaxFlips"]);
                        // Gán lại giá trị của score và maxFlips cho các thành viên trong lớp MainGame
                        lbl_time.Text = "Times: " + maxFlips.ToString();
                        label2.Text = "Score: " + score.ToString();
                        // Gán lại giá trị của maxFlips cho biến thành viên maxFlips trong lớp MainGame
                        this.maxFlips = maxFlips;
                        // Sau khi cập nhật giá trị từ cơ sở dữ liệu, gọi lại InitializeGame()
                        InitializeGame();
                    }
                    reader.Close();
                }
                sqlConnection.Close();
            }
        }
        private void MainGame_Load(object sender, EventArgs e)
        {
            isPaused = false;
            // Kết nối cơ sở dữ liệu
            // cập nhật userID mới nhất từ bảng Users sang bảng GameSessions
            // cập nhật GameID = 1 trong bảng GameSessions
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

                // Lấy userID mới nhất từ bảng User
                int latestUserID;
                string getUserIDQuery = "SELECT TOP 1 UserID FROM Users ORDER BY UserID DESC";
                using (SqlCommand command3 = new SqlCommand(getUserIDQuery, sqlConnection))
                {
                    latestUserID = (int)command3.ExecuteScalar();
                }
                // Thêm userID của người đang chơi, thời gian bắt đầu và GameID = 1 trong bảng GameSessions
                string insertGameSessionQuery = "INSERT INTO GameSessions (GameSessionID, GameID, userId, StartDate, EndDate, Score) VALUES (@GameSessionID, @GameID, @userId, @StartDate, @EndDate, @Score)";
                //string updateGameSessionsQuery = "UPDATE GameSessions SET UserID = @UserID, GameID = 1, GameSessionID=1";
                using (SqlCommand command2 = new SqlCommand(insertGameSessionQuery, sqlConnection))
                {
                    command2.Parameters.AddWithValue("@userId", latestUserID);
                    command2.Parameters.AddWithValue("@GameID", 1);
                    command2.Parameters.AddWithValue("@GameSessionID", maxGameSessionID + 1);
                    command2.Parameters.AddWithValue("@StartDate", DateTime.Now); // Thay thế bằng giá trị thời gian bắt đầu thích hợp
                    command2.Parameters.AddWithValue("@EndDate", DBNull.Value); // Thay thế bằng giá trị thời gian kết thúc thích hợp hoặc DBNull.Value nếu chưa có thông tin
                    command2.Parameters.AddWithValue("@Score", DBNull.Value); // Thay thế bằng giá trị điểm số thích hợp hoặc DBNull.Value nếu chưa có thông tin
                    command2.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
        }
    }
}

