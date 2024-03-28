using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMORY_MATCH
{
    public partial class Howtoplay : Form
    {
        private MainOption mainoption;
        public Howtoplay(MainOption form)
        {
            InitializeComponent();
            mainoption = form;
        }

       
      
        private void btn_exit_htp_Click(object sender, EventArgs e)
        {
            mainoption.SetButtonClickedStatus(false); // Đặt lại trạng thái của nút "btn_howtoplay" trong form hiện tại
            this.Close();
        }
    }
}
