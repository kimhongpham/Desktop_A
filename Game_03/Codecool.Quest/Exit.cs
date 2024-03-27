using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codecool.Quest
{
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {

            // Lấy form MainForm hiện tại
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                // Ẩn form MainForm
                mainForm.Hide();

                // Hoặc bạn có thể xóa form MainForm
                // mainForm.Dispose();
            }

            // Đóng form Exit
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_Load(object sender, EventArgs e)
        {

        }
    }
}
