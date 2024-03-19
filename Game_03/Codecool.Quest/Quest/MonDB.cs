using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Codecool.Quest.Quest
{
    public class MonDB
    {
        public static DataTable LayDSMon()
        { return Database1.SelectQuery("select * from Mon"); }
    }
}
