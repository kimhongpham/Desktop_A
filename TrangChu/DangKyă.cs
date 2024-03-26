using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using admin___tke;
using Codecool.Quest;

namespace Gaming_Dashboard
{
    public partial class DangKy1 : UserControl
    {
        public Main main;
        public event EventHandler BackButtonClicked;
        private static DangKy1 _instance;
        public static DangKy1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DangKy1();
                return _instance;
            }
        }


        public DangKy1()
        {
            InitializeComponent();
        }

        private void DangKy1_Load(object sender, EventArgs e)
        {

        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            if (BackButtonClicked != null)
                BackButtonClicked(this, EventArgs.Empty);
        }


        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_DKTenTaiKhoan.Text) && !string.IsNullOrEmpty(txt_DKEmail.Text) &&
                !string.IsNullOrEmpty(txt_DKMatKhau.Text) && !string.IsNullOrEmpty(txt_DKMatKhauNhapLai.Text))
            {
                if (txt_DKMatKhau.Text != txt_DKMatKhauNhapLai.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp.");
                    return;
                }

                // Hash the password
                var passwordHash = HashPassword(txt_DKMatKhau.Text);

                // Tạo tài khoản người dùng mới
                User newUser = new User
                {
                    Username = txt_DKTenTaiKhoan.Text,
                    Email = txt_DKEmail.Text,
                    Password = passwordHash
                };

                try
                {
                    using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                    {
                        sqlConnection.Open();
                        //MessageBox.Show("Kết nối thành công!");

                        // Thêm kiểm tra tên người dùng hiện có
                        string checkUsernameQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                        using (SqlCommand checkUsernameCommand = new SqlCommand(checkUsernameQuery, sqlConnection))
                        {
                            checkUsernameCommand.Parameters.AddWithValue("@Username", newUser.Username);

                            // Nếu tên người dùng đã tồn tại trong bảng Người dùng, hiển thị thông báo lỗi
                            if (Convert.ToInt32(checkUsernameCommand.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng sử dụng tên tài khoản khác.");
                                return;
                            }
                        }
                        // Kiểm tra mọi vòng lặp email địa chỉ
                        string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                        using (SqlCommand checkCommand = new SqlCommand(checkEmailQuery, sqlConnection))
                        {
                            checkCommand.Parameters.AddWithValue("@Email", newUser.Email);

                            // Nếu địa chỉ email đã tồn tại trong bảng Người dùng, hãy hiển thị thông báo lỗi
                            if (Convert.ToInt32(checkCommand.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show("Email đã tồn tại. Vui lòng sử dụng email khác.");
                                return;
                            }
                        }

                        // Định nghĩa truy vấn SQL để chèn dữ liệu người dùng vào bảng Users
                        string insertQuery = "INSERT INTO Users (Username, Email, Password, NGAYTHAMGIA) VALUES (@Username, @Email, @Password, GETDATE())";

                        // Chèn người dùng mới vào bảng Người dùng
                        using (SqlCommand command = new SqlCommand(insertQuery, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", newUser.Username);
                            command.Parameters.AddWithValue("@Email", newUser.Email);
                            command.Parameters.AddWithValue("@Password", newUser.Password);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Đăng ký thành công! Click 'OK' để đăng nhập.");

                            // Hiển thị thông báo thành công và chuyển đến trang chủ
                            this.Hide();
                            string username = txt_DKTenTaiKhoan.Text;
                            UserMain userMain = new UserMain(username);
                            this.main.Hide();
                            userMain.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedPassword = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashedPassword);
            }
        }
    }

    internal class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}