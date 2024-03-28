using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace admin___tke
{
    public partial class Reports : Form
    {
        private static Reports _instance;
        private static readonly object _lock = new object();

        public static Reports Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Reports();
                        }
                    }
                }

                return _instance;
            }
        }

        public Reports()
        {
            InitializeComponent();

            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT COUNT(*) FROM users";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                int numberOfUsers = (int)command.ExecuteScalar();

                label2.Text = $"{numberOfUsers}";

                sqlConnection.Close();
            }

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            Series series = new Series
            {
                ChartType = SeriesChartType.Pie,
            };
            chart.Series.Add(series);

            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            //chart.Legends.Add(legend);

            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT TOP 3 g.GameName, COUNT(*) FROM GameSessions gs " +
                               "JOIN Games g ON gs.GameID = g.GameID " +
                               "GROUP BY g.GameName " +
                               "ORDER BY COUNT(*) DESC";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string game = reader.GetString(0);
                        int count = reader.GetInt32(1);

                        series.Points.Add(new DataPoint { Label = game, YValues = new double[] { count } });
                    }
                }

                sqlConnection.Close();
            }

            guna2Panel3.Controls.Add(chart);

            // Tạo biểu đồ mới cho những người chơi hàng đầu
            Chart playerChart = new Chart();

            // Đặt thuộc tính Dock của biểu đồ thành Fill để chiếm toàn bộ biểu mẫu
            playerChart.Dock = DockStyle.Fill;

            // Đặt thuộc tính ChartArea của biểu đồ thành ChartArea mới
            playerChart.ChartAreas.Add(new ChartArea());

            // Đặt thuộc tính Sê-ri của biểu đồ thành Sê-ri mới
            playerChart.Series.Add(new Series { ChartType = SeriesChartType.Pie });

            // Nhận 5 người chơi hàng đầu dựa trên ID người dùng
            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT TOP 5 u.username, COUNT(*) FROM GameSessions gs " +
                                "JOIN users u ON gs.userid = u.userid " +
                                "GROUP BY u.username " +
                                "ORDER BY COUNT(*) DESC";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader.GetString(0);
                        int count = reader.GetInt32(1);

                        // Thêm dữ liệu người chơi hàng đầu vào biểu đồ
                        playerChart.Series[0].Points.Add(new DataPoint { Label = username, YValues = new double[] { count } });
                    }
                }

                sqlConnection.Close();
            }

            // Thêm biểu đồ vào điều khiển guna2Panel4
            guna2Panel4.Controls.Add(playerChart);

            Chart userPerDayChart = new Chart();
            userPerDayChart.Dock = DockStyle.Fill;

            ChartArea userPerDayArea = new ChartArea();
            userPerDayArea.Name = "UserPerDayArea";
            userPerDayChart.ChartAreas.Add(userPerDayArea);

            Series userPerDaySeries = new Series
            {
                ChartType = SeriesChartType.Line,
                Name = "UserPerDaySeries"
            };
            userPerDayChart.Series.Add(userPerDaySeries);

            // Lấy số lượng người dùng tham gia mỗi ngày
            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT COUNT(*) as count, CAST(NGAYTHAMGIA as DATE) as date " +
                               "FROM Users " +
                               "WHERE NGAYTHAMGIA IS NOT NULL " +
                               "GROUP BY CAST(NGAYTHAMGIA as DATE) " +
                               "ORDER BY CAST(NGAYTHAMGIA as DATE)";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(1);
                        int count = reader.GetInt32(0);

                        double xValue = date.ToOADate();

                        DataPoint dataPoint = new DataPoint(xValue, count);
                        dataPoint.Label = count.ToString(); // Đặt giá trị Label thành số lượng

                        userPerDaySeries.Points.Add(dataPoint);
                    }
                }

                sqlConnection.Close();
            }

            // Đặt loại giá trị X thành Ngày
            userPerDaySeries.XValueType = ChartValueType.Date;

            // Định dạng nhãn trục X để hiển thị ngày ở định dạng "dd/MM/yyyy"
            userPerDayChart.ChartAreas["UserPerDayArea"].AxisX.LabelStyle.Format = "dd/MM/yyyy";

            // Thêm biểu đồ vào điều khiển pnl_c3
            pnl_c3.Controls.Add(userPerDayChart);

            // Tạo điều khiển biểu đồ mới
            Chart columnChart = new Chart();

            // Đặt thuộc tính Dock để lấp đầy vùng chứa
            columnChart.Dock = DockStyle.Fill;

            // Tạo một khu vực biểu đồ
            ChartArea columnArea = new ChartArea();
            columnArea.Name = "ColumnArea";

            // Đặt AxesTitleStyle cho trục X và Y
            columnArea.AxisX.Title = "Ngày";
            columnArea.AxisY.Title = "Số lượng người chơi mỗi ngày";

            // Đặt ChartArea cho biểu đồ
            columnChart.ChartAreas.Add(columnArea);
            columnChart.Legends.Add(new Legend("Legend"));
            columnChart.Legends["Legend"].Docking = Docking.Right;

            // Nhận kết nối
            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                // Chuẩn bị truy vấn
                string query = @"
        SELECT CONVERT(date, StartDate) AS GameDate,
            (SELECT GameName FROM Games WHERE GameID = gs.GameID) AS GameName,
            COUNT(*) AS PlayersCount
        FROM GameSessions gs
        WHERE gs.GameID IN (1, 2, 3)
            AND StartDate IS NOT NULL
        GROUP BY CONVERT(date, StartDate), gs.GameID
        ORDER BY CONVERT(date, StartDate);
    ";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                // Thực hiện truy vấn và điền vào biểu đồ
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    HashSet<string> addedGameNames = new HashSet<string>();
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        string gameName = reader.GetString(1);
                        int playerCount = reader.GetInt32(2);

                        // Kiểm tra xem chuỗi có tồn tại chưa
                        bool seriesExists = false;

                        foreach (Series existingSeries in columnChart.Series)
                        {
                            if (existingSeries.Name == gameName)
                            {
                                seriesExists = true;
                                break;
                            }
                        }

                        // Nếu chuỗi chưa tồn tại, thêm chuỗi mới vào biểu đồ
                        if (!seriesExists)
                        {
                            Series newSeries = new Series
                            {
                                ChartType = SeriesChartType.Column, // Thay đổi loại biểu đồ thành Column (cột)
                                Name = gameName,
                                IsValueShownAsLabel = true
                            };
                            columnChart.Series.Add(newSeries);
                        }

                        // Thêm điểm dữ liệu vào chuỗi
                        columnChart.Series[gameName].Points.AddXY(date, playerCount);
                        if (!addedGameNames.Contains(gameName))
                        {
                            addedGameNames.Add(gameName);

                            // Thêm mục chú giải cho tên trò chơi
                            columnChart.Legends["Legend"].CustomItems.Add(new LegendItem(gameName, columnChart.Series[gameName].Color, ""));
                        }
                    }
                }

                sqlConnection.Close();
            }

            // Thêm biểu đồ vào vùng chứa
            pnl_c4.Controls.Add(columnChart);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Down_Click(object sender, EventArgs e)
        {

        }
        private void btn_GamePage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Player ap = new Admin_Player();
            ap.ShowDialog();
        }
    }
}