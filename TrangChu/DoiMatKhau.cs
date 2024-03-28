using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gaming_Dashboard
{
    public partial class DoiMatKhau : UserControl
    {
        public Main main;
        public string UserEmail { get; set; }
        private object password;
        public DoiMatKhau()
        {
            InitializeComponent();

        }
        private static DoiMatKhau _instance;

        public static DoiMatKhau Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DoiMatKhau();
                return _instance;
            }
        }


        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txt_NhapMaXacMinh.Text == "12345")
            {
                MessageBox.Show("Xác thực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã xác thực không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void btn_MatKhauNhapLai_Click(object sender, EventArgs e)
        {
            if (txt_NhapMaXacMinh.Text == "12345")
            {
                if (!string.IsNullOrEmpty(txt_MatKhau.Text) && !string.IsNullOrEmpty(txt_MatKhauNhapLai.Text))
                {
                    if (txt_MatKhau.Text != txt_MatKhauNhapLai.Text)
                    {
                        MessageBox.Show("Mật khẩu mới không khớp.");
                        return;
                    }
                    try
                    {
                        // Use the UserEmail property
                        using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                        {
                            sqlConnection.Open();
                            string sql = "UPDATE Users SET Password = @Password WHERE Email = @Email";
                            SqlCommand command = new SqlCommand(sql, sqlConnection);
                            command.Parameters.AddWithValue("@Email", UserEmail);
                            command.Parameters.AddWithValue("@Password", HashPassword(txt_MatKhau.Text));
                            command.ExecuteNonQuery();
                        }
                        // Hiển thị thông báo thành công và chuyển đến trang chủ
                        MessageBox.Show("Mật khẩu của bạn đã được thiết lập lại. Vui lòng đăng nhập bằng mật khẩu mới của bạn.");
                        //Main smain = new Main();
                        //this.main.Hide();
                        //smain.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Mã xác thực không đúng. Vui lòng kiểm tra lại.");
                }

                // Ẩn ô nhập mã xác minh và hướng dẫn
                lbl_DatLaiMatKhau.Text = "";
                btn_MatKhauNhapLai.Visible = false;
                txt_MatKhau.Clear();
                txt_MatKhauNhapLai.Clear();
            }
            else
            {
                MessageBox.Show("Mã xác thực không đúng. Vui lòng kiểm tra lại.");
            }
        }
    }
}