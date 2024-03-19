using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Quest
{
    public class CauHoiBus
    {
        public string noidung { get; set; }
        public int mon { get; set; }
        public string dapan1 { get; set; }
        public string dapan2 { get; set; }
        public string dapan3 { get; set; }
        public string dapan4 { get; set; }
        public string dapan { get; set; }
        public static List<CauHoiBus> LayDSCauHoi( int mon)
        {
            DataTable dt = CauHoiDB.LayDSCauHoi( mon);
            List<CauHoiBus> list = new List<CauHoiBus>();
            foreach (DataRow dr in dt.Rows)
            {
                CauHoiBus item = new CauHoiBus();
                item.noidung = Convert.ToString(dr["NoiDung"]).Trim();
                //item.lop = lop;//item.lop=Convert.ToInt32(dr["Lop"]);
                item.mon = mon;//tuong tu nhu tren
                item.dapan1 = Convert.ToString(dr["DA1"]).Trim();
                item.dapan2 = Convert.ToString(dr["DA2"]).Trim();
                item.dapan3 = Convert.ToString(dr["DA3"]).Trim();
                item.dapan4 = Convert.ToString(dr["DA4"]).Trim();
                item.dapan = Convert.ToString(dr["DA"]).Trim();
                list.Add(item);
            }
            return list;
        }
    }
}
