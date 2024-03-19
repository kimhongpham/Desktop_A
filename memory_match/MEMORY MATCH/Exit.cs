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
    public partial class Exit : Form
    {

        public Exit()
        {
            InitializeComponent();
        }

        private void btn_yes_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_no_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
