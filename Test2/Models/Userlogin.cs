using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
	public class Userlogin
	{
		[Key]
		public int Id { get; set; }
		public int Userid { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
		public int Roleid { get; set; }
	}
}
