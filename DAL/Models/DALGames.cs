using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;	

namespace DAL.Models
{
	public class DALGames
	{
		[Key]
		public int GameID { get; set; }
		public string GameName { get; set; }
		public DateTime NGAYPHATHANH { get; set; }
		public string TheLoai { get; set; }
	}
}