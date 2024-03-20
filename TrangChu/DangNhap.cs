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


namespace Gaming_Dashboard
{
    public partial class DangNhap : UserControl
    {
        public Main main;
        private UserControl previousUserControl;
        public static string loggedInUsername;
        public DangNhap()
        {
            InitializeComponent();
        }
        private static DangNhap _instance;
        public static DangNhap Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DangNhap();
                return _instance;
            }
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!pn_DangNhap2.Controls.Contains(QuenMatKhau.Instance))
            {
                pn_DangNhap2.Controls.Add(QuenMatKhau.Instance);
                QuenMatKhau.Instance.Dock = DockStyle.Fill;
                pn_DangNhap2.BringToFront();
                AutoScroll = false;
                QuenMatKhau.Instance.BringToFront();
            }
            else
                pn_DangNhap.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        public void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!pn_DangNhap2.Controls.Contains(DangKy1.Instance))
            {
                pn_DangNhap2.Controls.Add(DangKy1.Instance);
                DangKy1.Instance.Dock = DockStyle.Fill;
                pn_DangNhap2.BringToFront();
                AutoScroll = false;
                DangKy1.Instance.BringToFront();
            }
            else
                pn_DangNhap.BringToFront();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbl_DangNhap_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_MatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string email = txt_DNEmail.Text;
            string password = txt_DNMatKhau.Text;

            // Xác thực email và mật khẩu
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu.");
                return;
            }

            // Thực hiện logic đăng nhập
            bool isLoggedIn = PerformLogin(email, password);

            if (isLoggedIn)
            {
                // Đóng biểu mẫu đăng nhập và mở biểu mẫu chính
                this.Hide();
                UserMain userMain = new UserMain(loggedInUsername); // pass the username to the UserMain constructor
                this.main.Hide();
                userMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng.");
            }
        }
        private bool PerformLogin(string email, string password)
        {
            //const
            //string connectionString = "Data Source = ROSIE - PHAM\SQLEXPRESS; Initial Catalog = game_databaseA; Persist Security Info = True; User ID = rosie0107; Password = ***********; Encrypt = True; Trust Server Certificate = True";
            //string connectionString = "Data Source = ROSIE - PHAM\SQLEXPRESS; Initial Catalog = game_databaseA; Integrated Security = True; Encrypt = True; Trust Server Certificate = True";
            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Admin\\Documents\\Tài liệu\\Desktop_A\\TrangChu\\Database1.mdf\";Integrated Security=True";
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string sql = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Set the loggedInUsername variable
                    loggedInUsername = reader["Username"].ToString();

                    // Close the connection and return true
                    sqlConnection.Close();
                    return true;
                }
                else
                {
                    // Close the connection and return false
                    sqlConnection.Close();
                    return false;
                }
            }
        }
    }
}