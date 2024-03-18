using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Quest
{
    public class CauHoiDB
    {
        public static DataTable LayDSCauHoi( int mon)
        {
            return Database1.SelectQuery("select * from CauHoi where Mon=" + mon);
        }
    }
}
