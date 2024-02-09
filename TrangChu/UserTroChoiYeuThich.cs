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
    public partial class UserTroChoiYeuThich : UserControl
    {
        public UserTroChoiYeuThich()
        {
            InitializeComponent();
        }
        private static UserTroChoiYeuThich _instance;
        public static UserTroChoiYeuThich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserTroChoiYeuThich();
                return _instance;
            }
        }
        private void guna2PictureBox22_Click(object sender, EventArgs e)
        {

        }
    }
}
