
using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gaming_Dashboard
{
    public partial class BangXepHang : UserControl
    {
        public BangXepHang()
        {
            InitializeComponent();

            // Kết nối với cơ sở dữ liệu và lấy thứ hạng
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT u.UserName, gs.Score FROM GameSessions gs " +
                                                   "JOIN Users u ON gs.UserID = u.UserID " +
                                                   "JOIN UserGames ug ON gs.GameID = ug.GameID " +
                                                   "JOIN Games g ON gs.GameID = g.GameID " +
                                                   "ORDER BY gs.Score DESC", sqlConnection);
                SqlDataReader reader = command.ExecuteReader();


                int index = 0;
                while (reader.Read())
                {
                    switch (index)
                    {
                        case 0:
                            label7.Text = reader["UserName"].ToString();
                            label8.Text = reader["Score"].ToString();
                            break;
                        case 1:
                            label10.Text = reader["UserName"].ToString();
                            label9.Text = reader["Score"].ToString();
                            break;
                        case 2:
                            label12.Text = reader["UserName"].ToString();
                            label11.Text = reader["Score"].ToString();
                            break;
                    }

                    // Thêm hình ảnh vào Guna2Button
                    Guna2Button button = new Guna2Button();
                    button.Text = $"{reader["Rank"]}. {reader["UserName"]} - {reader["Score"]}";
                    switch (index)
                    {
                        case 0:
                            guna2Button9.Controls.Add(button);
                            break;
                        case 1:
                            guna2Button1.Controls.Add(button);
                            break;
                        case 2:
                            guna2Button2.Controls.Add(button);
                            break;
                    }
                    index++;
                }

                sqlConnection.Close();

            }
        }
        private static BangXepHang _instance;
        public static BangXepHang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BangXepHang();
                return _instance;
            }
        }
        private void BangXepHang_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
