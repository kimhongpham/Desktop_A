using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace admin___tke
{
    public partial class Reports : Form
    {
        public partial class ReportsManager
        {
            private static Reports _instance;
            public static Reports Instance()
            {
                if (_instance == null) _instance = new Reports();
                return _instance;
            }
        }
        public Reports()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT MAX(userid) FROM users";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                int lastUserId = (int)command.ExecuteScalar();

                label2.Text = $"{lastUserId}";

                sqlConnection.Close();
            }
            // Tạo điều khiển Biểu đồ mới
            Chart chart = new Chart();

            // Đặt thuộc tính Dock của biểu đồ thành Fill để nó chiếm toàn bộ biểu mẫu
            chart.Dock = DockStyle.Fill;

            // Đặt thuộc tính ChartArea của biểu đồ thành ChartArea mới
            chart.ChartAreas.Add(new ChartArea());

            // Đặt thuộc tính Chuỗi của biểu đồ thành Chuỗi mới
            chart.Series.Add(new Series { ChartType = SeriesChartType.Pie });

            /*// Thêm dữ liệu trạng thái người chơi vào biểu đồ
            using (SqlConnection sqlConnection = Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT status, COUNT(*) FROM users GROUP BY status";
                SqlCommand command = new SqlCommand(query, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader.GetString(0);
                        int count = reader.GetInt32(1);

                        // Thêm một Điểm mới vào chuỗi biểu đồ kèm theo trạng thái và số lượng
                        chart.Series[0].Points.Add(new DataPoint { Label = status, YValues = new double[] { count } });
                    }
                }

                sqlConnection.Close();
            }

            // Thêm biểu đồ vào điều khiển guna2Panel2
            guna2Panel2.Controls.Add(chart);*/
            // Get the top game data
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

                        // Add the top game data to the chart
                        chart.Series[0].Points.Add(new DataPoint { Label = game, YValues = new double[] { count } });
                    }
                }

                sqlConnection.Close();
            }

            // Thêm biểu đồ vào điều khiển guna2Panel3
            guna2Panel3.Controls.Add(chart);

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
    }
}
