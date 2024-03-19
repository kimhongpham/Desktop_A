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
    public partial class Record : Form
    {
        private MainOption mainoption;
        public Record(MainOption form)
        {
            InitializeComponent();
            this.mainoption = form;
        }

        private void btn_exit_record_Click(object sender, EventArgs e)
        {
            mainoption.EventClick();
            mainoption.SetButtonClickedStatus(false);
            Close();
        }
    }
}
