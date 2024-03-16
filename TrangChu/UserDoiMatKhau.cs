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
    public partial class UserDoiMatKhau : UserControl
    {
        public UserDoiMatKhau()
        {
            InitializeComponent();
        }
        private static UserDoiMatKhau _instance;
        public static UserDoiMatKhau Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserDoiMatKhau();
                return _instance;
            }
        }
    }
}
