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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaming_Dashboard
{
    public partial class UserThongTinCaNhan : UserControl
    {
        private string _username; // khai báo một trường riêng tư để lưu trữ tên người dùng
        public UserThongTinCaNhan(string username)
        {
            InitializeComponent();
            _username = username; // đặt trường riêng tư thành tên người dùng
        }
        private static UserThongTinCaNhan _instance;
        public static string loggedInUsername;

        public static UserThongTinCaNhan Instance(string username)
        {
            if (_instance == null)
                _instance = new UserThongTinCaNhan(username);
            return _instance;
        }

        private void txt_ten_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Tạo kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=ROSIE-PHAM\\SQLEXPRESS;Initial Catalog=game_databaseA;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Truy xuất thông tin của người dùng từ các điều khiển biểu mẫu
                int userId = GetUserIdFromUsername(_username);
                string firstName = txt_ten.Text;
                string lastName = txt_Ho.Text;
                string phoneNumber = txt_SoDienThoai.Text;
                string country = txt_QuocGia.Text;
                string city = txt_ThanhPho.Text;
                string address = txt_DiaChi.Text;

                // Tạo lệnh cập nhật thông tin người dùng vào cơ sở dữ liệu
                string updateCommand = "UPDATE Users SET TEN = @FirstName, HO = @LastName, SDT = @PhoneNumber, QUOCGIA = @Country, THANHPHO = @City, Address = @Address WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(updateCommand, connection))
                {
                    // Đặt giá trị tham số cho lệnh
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        // Thực hiện lệnh cập nhật thông tin người dùng vào cơ sở dữ liệu
                        command.ExecuteNonQuery();

                        // Hiển thị hộp thông báo để cho biết cập nhật đã thành công
                        MessageBox.Show("Thông tin của bạn đã được cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị hộp thông báo lỗi nếu cập nhật không thành công
                        MessageBox.Show($"Đã xảy ra lỗi khi cập nhật thông tin của bạn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private int GetUserIdFromUsername(string username)
        {
            // Create a connection to the database
            string connectionString = "Data Source=ROSIE-PHAM\\SQLEXPRESS;Initial Catalog=game_databaseA;Integrated Security=True";
            int userId = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a command to retrieve the user's ID from the database
                string selectCommand = "SELECT UserID FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    // Set the parameter value for the command
                    command.Parameters.AddWithValue("@UserName", username);

                    // Execute the command and retrieve the user's ID
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                        }
                    }
                }
            }

            return userId;
        }
    }
}
