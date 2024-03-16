using System;
using System.Data;
using System.Data.SqlClient;
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
            // Xác thực việc nhập email
            if (string.IsNullOrEmpty(txt_EmailXacMinh.Text))
            {
                MessageBox.Show("Vui lòng nhập email của bạn.");
                return;
            }

            // Kiểm tra email đã đăng ký chưa
            bool isRegistered = CheckEmailRegistration(txt_EmailXacMinh.Text);

            if (isRegistered)
            {
                // Tạo và gửi mã xác minh đến địa chỉ email của người dùng
                Random random = new Random();
                string verificationCode = random.Next(100000, 999999).ToString();
                MailMessage mail = new MailMessage("your-email@example.com", txt_EmailXacMinh.Text);
                mail.Subject = "Mã xác minh đặt lại mật khẩu";
                mail.Body = $"Mã xác minh của bạn là: {verificationCode}";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("your-email@gmail.com", "your-email-password");
                smtp.EnableSsl = true;

                // Gửi email
                try
                {
                    smtp.Send(mail);

                    // Đóng biểu mẫu QuenMatKhau hiện tại
                    this.Hide();
                    DoiMatKhau DoiMatKhau = new DoiMatKhau();
                    //DoiMatKhau.ShowDialog();
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show("Lỗi gửi email: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Email này chưa đăng ký.");
            }
        }

        // Phương thức kiểm tra đăng ký email
        private bool CheckEmailRegistration(string email)
        {
            bool isRegistered = false;

            try
            {
                string connectionString = "Data Source=ROSIE-PHAM\\SQLEXPRESS;Initial Catalog=game_databaseA;Integrated Security=True;Pooling=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        int result = (int)command.ExecuteScalar();

                        isRegistered = result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }

            return isRegistered;
        }
    }
}