using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
	public class Semester
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
	}
}
