using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class DALUsers
	{
		[Key]
		public int UserID { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime NGAYTHAMGIA { get; set; }
		public string TEN { get; set; }
		public string HO { get; set; }
		public string SDT { get; set; }
		public string QUOCGIA { get; set; }
		public string THANHPHO { get; set; }
		public string Address { get; set; }
	}
}