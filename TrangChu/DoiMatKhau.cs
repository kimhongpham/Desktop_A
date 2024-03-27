using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gaming_Dashboard
{
    public partial class DoiMatKhau : UserControl
    {

        public DoiMatKhau()
        {
            InitializeComponent();

        }
        private static DoiMatKhau _instance;
        private object email;
        private object password;

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
            
        }

        private void btn_MatKhauNhapLai_Click(object sender, EventArgs e)
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
                    using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
                    {
                        sqlConnection.Open(); // Mở kết nối
                        string sql = "UPDATE Users SET Password = @Password WHERE Email = @Email";
                        SqlCommand command = new SqlCommand(sql, sqlConnection);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    // Hiển thị thông báo thành công và chuyển đến trang chủ
                    MessageBox.Show("Mật khẩu của bạn đã được thiết lập lại. Vui lòng đăng nhập bằng mật khẩu mới của bạn.");
                    this.Hide();
                    //UserMain userMain = new UserMain();
                    //userMain.ShowDialog();
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
            // Ẩn ô nhập mã xác minh và hướng dẫn
            lbl_DatLaiMatKhau.Text = "";
            btn_MatKhauNhapLai.Visible = false;
            txt_MatKhau.Clear();
            txt_MatKhauNhapLai.Clear();
        }
    }
}