using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Gaming_Dashboard
{
    public partial class QuenMatKhau : UserControl
    {
        private static QuenMatKhau _instance;
        public DoiMatKhau DoiMatKhauForm { get; private set; }

        public static QuenMatKhau Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QuenMatKhau();
                return _instance;
            }
        }

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi nút Xác Minh được nhấn
        private void btn_XacMinh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_EmailXacMinh.Text))
            {
                MessageBox.Show("Vui lòng nhập email của bạn.");
                return;
            }

            bool isRegistered = CheckEmailRegistration(txt_EmailXacMinh.Text);

            if (isRegistered)
            {
                User user = GetUserByEmail(txt_EmailXacMinh.Text);
                if (user != null)
                {
                    MessageBox.Show("Mật khẩu của bạn là: " + user.Password);
                    this.Hide();
                    var loginForm = new DangNhap();
                    loginForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Email này chưa đăng ký.");
            }
        }

        private User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                {
                    sqlConnection.Open();

                    string sql = "SELECT * FROM Users WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Password = reader["Password"].ToString()
                                };
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }

            return user;
        }

        private bool CheckEmailRegistration(string email)
        {
            bool isRegistered = false;

            try
            {
                using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                {
                    sqlConnection.Open();

                    string sql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        int result = (int)command.ExecuteScalar();

                        isRegistered = result > 0;
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }

            return isRegistered;
        }
    }
}