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
                // Tạo tài khoản người dùng mới
                User newUser = new User
                {
                    Username = txt_DKTenTaiKhoan.Text,
                    Email = txt_DKEmail.Text,
                    Password = txt_DKMatKhau.Text
                };

                string connectionString = "Data Source=ROSIE-PHAM\\SQLEXPRESS;Initial Catalog=game_databaseA;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open(); // Mở kết nối
                        MessageBox.Show("Kết nối thành công!");

                        // Định nghĩa truy vấn SQL để chèn dữ liệu người dùng và lấy UserID được tạo ra
                        string sql = "INSERT INTO Users (Username, Email, Password, NGAYTHAMGIA) VALUES (@Username, @Email, @Password, GETDATE()); SELECT SCOPE_IDENTITY()";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Username", newUser.Username);
                            command.Parameters.AddWithValue("@Email", newUser.Email);
                            command.Parameters.AddWithValue("@Password", newUser.Password);

                            // Thực thi truy vấn và lấy UserID được tạo ra
                            int userID = Convert.ToInt32(command.ExecuteScalar());
                            MessageBox.Show("Chèn thành công! UserID: " + userID);
                        }
                    }
                    // Hiển thị thông báo thành công và chuyển đến trang chủ
                    MessageBox.Show("Đăng ký thành công!");
                    this.Hide();
                    string username = txt_DKTenTaiKhoan.Text; // get the username
                    UserMain userMain = new UserMain(username); // create a new instance of UserMain and pass the username
                    this.main.Hide();
                    userMain.ShowDialog();
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

    }

    internal class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
