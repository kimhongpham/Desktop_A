using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace admin___tke
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void lbl_BaoCao_Click(object sender, EventArgs e)
        {
            if (!AdminSelect.Controls.Contains(ReportsManager.Instance()))
            {
                AdminSelect.Controls.Add(ReportsManager.Instance());
                ReportsManager.Instance().Dock = DockStyle.Fill;
                AdminSelect.BringToFront();
                AutoScroll = false;
                ReportsManager.Instance().BringToFront();
            }
            else
                ReportsManager.Instance().BringToFront();
        }
    }
}