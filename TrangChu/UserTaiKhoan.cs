﻿using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaming_Dashboard
{
    public partial class UserTaiKhoan : UserControl
    {
        public UserMain usermain;
        public Main main;
        private string _username; // khai báo một trường riêng tư để lưu trữ tên người dùng

        public UserTaiKhoan(string username)
        {
            InitializeComponent();
            _username = username; // đặt trường riêng tư thành tên người dùng
            lbl_Username.Text = _username; // đặt văn bản của nhãn thành tên người dùng
        }

        private static UserTaiKhoan _instance;
        public static UserTaiKhoan Instance(string username)
        {
            if (_instance == null)
                _instance = new UserTaiKhoan(username);
            return _instance;
        }

        private void UserTaiKhoan_Load(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserThongTinCaNhan.Instance(_username)))
            {
                guna2Panel1.Controls.Add(UserThongTinCaNhan.Instance(_username));
                UserThongTinCaNhan.Instance(_username).Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserThongTinCaNhan.Instance(_username).BringToFront();
            }
            else
                UserThongTinCaNhan.Instance(_username).BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserThanhTich.Instance(_username)))
            {
                guna2Panel1.Controls.Add(UserThanhTich.Instance(_username));
                UserThanhTich.Instance(_username).Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserThanhTich.Instance(_username).BringToFront();
            }
            else
                UserThanhTich.Instance(_username).BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserCaiDat.Instance))
            {
                guna2Panel1.Controls.Add(UserCaiDat.Instance);
                UserCaiDat.Instance.Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserCaiDat.Instance.BringToFront();
            }
            else
                UserCaiDat.Instance.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserThongTinCaNhan.Instance(_username)))
            {
                guna2Panel1.Controls.Add(UserThongTinCaNhan.Instance(_username));
                UserThongTinCaNhan.Instance(_username).Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserThongTinCaNhan.Instance(_username).BringToFront();
            }
            else
                UserThongTinCaNhan.Instance(_username).BringToFront();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Controls.Contains(UserDoiMatKhau.Instance(_username)))
            {
                guna2Panel1.Controls.Add(UserDoiMatKhau.Instance(_username));
                UserDoiMatKhau.Instance(_username).Dock = DockStyle.Fill;
                guna2Panel1.BringToFront();
                AutoScroll = false;
                UserDoiMatKhau.Instance(_username).BringToFront();
            }
            else
                UserDoiMatKhau.Instance(_username).BringToFront();
        }


        private void lbl_Username_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Users WHERE UserName = @username";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@username", _username);

                SqlDataReader reader = command.ExecuteReader();

                StringBuilder userInfo = new StringBuilder();

                if (reader.Read())
                {
                    userInfo.AppendLine($"ID: {reader["UserID"]}");
                    userInfo.AppendLine($"Username: {reader["UserName"]}");
                    userInfo.AppendLine($"Email: {reader["Email"]}");
                    userInfo.AppendLine($"Password: {reader["Password"]}");
                    userInfo.AppendLine($"Join Date: {reader["NGAYTHAMGIA"]}");
                    userInfo.AppendLine($"First Name: {reader["TEN"]}");
                    userInfo.AppendLine($"Last Name: {reader["HO"]}");
                    userInfo.AppendLine($"Phone: {reader["SDT"]}");
                    userInfo.AppendLine($"Country: {reader["QUOCGIA"]}");
                    userInfo.AppendLine($"City: {reader["THANHPHO"]}");
                    userInfo.AppendLine($"Address: {reader["Address"]}");
                }
                else
                {
                    MessageBox.Show($"No user found with username '{_username}'.");
                    return;
                }

                MessageBox.Show(userInfo.ToString());

                sqlConnection.Close();
            }
        }

        private void lbl_DangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main Main = new Main(); 
            this.usermain.Hide();
            Main.ShowDialog();
        }
    }
}
