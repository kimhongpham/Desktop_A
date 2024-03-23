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
        private Reports _reportsForm;

        public Admin()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private List<Form> _mdiChildren = new List<Form>();

        private void lbl_BaoCao_Click(object sender, EventArgs e)
        {
            /*if (_reportsForm == null)
            {
                _reportsForm = new Reports();
            }

            // Set the reports form's MdiParent property
            _reportsForm.MdiParent = this;

            // Add the reports form to the MdiChildren collection
            this.IsMdiContainer = true;
            this.MdiChildren.Add(_reportsForm);


            // Bring the reports form to the front
            _reportsForm.BringToFront();*/
        }
    }

}