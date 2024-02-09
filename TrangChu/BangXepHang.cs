using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaming_Dashboard
{
    public partial class BangXepHang : UserControl
    {
        public BangXepHang()
        {
            InitializeComponent();
        }
        private static BangXepHang _instance;
        public static BangXepHang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BangXepHang();
                return _instance;
            }
        }
        private void BangXepHang_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
