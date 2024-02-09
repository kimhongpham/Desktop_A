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
    public partial class UserThongTinCaNhan : UserControl
    {
        public UserThongTinCaNhan()
        {
            InitializeComponent();
        }
        private static UserThongTinCaNhan _instance;
        public static UserThongTinCaNhan Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserThongTinCaNhan();
                return _instance;
            }
        }
    }
}
