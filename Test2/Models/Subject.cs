using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
	public class Subject
	{
		[Key]
		public int Id { get; set; }	
		public string? Name { get; set; }	
	}
}
