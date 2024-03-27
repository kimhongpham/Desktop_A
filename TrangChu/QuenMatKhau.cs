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
        private string otp;

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
                // Tạo và gửi mã OTP đến địa chỉ email của người dùng
                otp = GenerateOTP();
                SendOTP(txt_EmailXacMinh.Text, otp);

                // Đóng biểu mẫu QuenMatKhau hiện tại
                this.Hide();

                // Hiển thị biểu mẫu DoiMatKhau và chuyển mã OTP
                //DoiMatKhauForm = new DoiMatKhau(otp);
                //DoiMatKhauForm.ShowDialog();
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
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }

            return isRegistered;
        }

        // Phương thức tạo mã OTP ngẫu nhiên
        private string GenerateOTP()
        {
            Random random = new Random();
            int otpValue = random.Next(100000, 999999);
            return otpValue.ToString();
        }

        // Phương thức gửi OTP đến địa chỉ email
        private void SendOTP(string email, string otp)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("louica0107@gmail.com");
                    string dynamicEmail = txt_EmailXacMinh.Text;
                    mail.To.Add(dynamicEmail);
                    mail.Subject = "OTP";
                    mail.Body = "<h1>12345</h1>";
                    mail.IsBodyHtml = true;

                    // Attach a file from a URL instead of a local file path
                    //mail.Attachments.Add(new Attachment("https://example.com/file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("louica0107@gmail.com", "spzh jjvl ndtg tsrn");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Failed to send OTP: " + ex.Message);
            }
        }
    }
}