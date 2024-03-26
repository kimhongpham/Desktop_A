using admin___tke;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaming_Dashboard
{
    public partial class UserDoiMatKhau : UserControl
    {
        private string _username;

        public UserDoiMatKhau(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private static UserDoiMatKhau _instance;
        public static string loggedInUsername;

        public static UserDoiMatKhau Instance(string username)
        {
            if (_instance == null)
                _instance = new UserDoiMatKhau(username);
            return _instance;
        }

        private int GetUserIdFromUsername(string username)
        {
            int userId = -1;
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string selectCommand = "SELECT UserID FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(selectCommand, sqlConnection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                        }
                    }
                }
                sqlConnection.Close();
            }

            return userId;
        }
        public void ResetPassword(string newPassword)
        {
            // Get user ID
            int userId = GetUserIdFromUsername(_username);

            // Update password
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                using (var command = new SqlCommand("UPDATE Users SET Password = @Password WHERE UserID = @UserID", sqlConnection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Password", HashPassword(newPassword));

                    command.ExecuteNonQuery();

                    // Get updated password
                    var command2 = new SqlCommand("SELECT Password FROM Users WHERE UserID = @UserID", sqlConnection);
                    command2.Parameters.AddWithValue("@UserID", userId);

                    var newPasswordHash = (string)command2.ExecuteScalar();

                    // Update the label
                    txt_MatKhauMoi.Text = newPasswordHash;
                }
            }

            // Show success message
            MessageBox.Show("Đổi mật khẩu thành công!");

            // Reset the form
            ClearForm();
        }
        private string HashPassword(string password)
        {
            // Hash the password
            // You can use a password hashing library like bcrypt or Argon2
            // for better security

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void ClearForm()
        {
            txt_MatKhauCu.Clear();
            txt_MatKhauMoi.Clear();
            txt_MatKhauMoiNhapLai.Clear();
        }

        private void btn_NhapLaiMK_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txt_MatKhauCu.Text)
                || string.IsNullOrWhiteSpace(txt_MatKhauMoi.Text)
                || string.IsNullOrWhiteSpace(txt_MatKhauMoiNhapLai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }

            if (txt_MatKhauMoi.Text != txt_MatKhauMoiNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp");
                return;
            }

            // Reset password
            ResetPassword(txt_MatKhauMoi.Text);
        }
    }
}
