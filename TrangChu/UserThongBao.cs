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
    public partial class UserThongBao : UserControl
    {
        public UserThongBao()
        {
            InitializeComponent();
        }
        private static UserThongBao _instance;
        public static UserThongBao Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserThongBao();
                return _instance;
            }
        }
    }
}
