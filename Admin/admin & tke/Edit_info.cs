using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admin___tke
{
    public partial class Edit_info : Form
    {
        public Edit_info()
        {
            InitializeComponent();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            dgv_Player.DataSource = GetUser();
        }
        DataSet GetUser() { DataSet ds = new DataSet(); return ds; }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại thông báo khi button được nhấn
            DialogResult result = MessageBox.Show("Would you like to invite this user to become an administrator?", "Confirmation", MessageBoxButtons.OKCancel);

            // Xử lý kết quả từ hộp thoại thông báo
            if (result == DialogResult.OK)
            {
                // Người dùng chọn OK
                // Thực hiện hành động tương ứng ở đây
                MessageBox.Show("You have invited the user to become an administrator.");
            }
            else if (result == DialogResult.Cancel)
            {
                // Người dùng chọn Cancel
                // Thực hiện hành động tương ứng ở đây
                MessageBox.Show("You have cancelled the invitation.");
            }
        }

        private void dgv_Player_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
