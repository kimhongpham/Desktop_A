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
    public partial class UserThanhTich : UserControl
    {
        public UserThanhTich()
        {
            InitializeComponent();
        }
        private static UserThanhTich _instance;
        public static UserThanhTich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserThanhTich();
                return _instance;
            }
        }
    }
}
