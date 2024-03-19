using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DALGameSessions
    {
        [Key]
        public int GameSessionID { get; set; }

        [ForeignKey("DALUsers")]
        public int UserID { get; set; }

        [ForeignKey("DALGames")]
        public int GameID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Score { get; set; }
    }
}