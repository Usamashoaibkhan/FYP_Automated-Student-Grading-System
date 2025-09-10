using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
	public class Teacher
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public int Subjectid { get; set; }
		public int Roleid { get; set; }
		public int Departmentid { get; set; }
		public int Semesterid { get; set; }
		public string? Cnic { get; set; }
		[NotMapped]
		public string? Depname { get; set; }
		[NotMapped]
		public string? Subjectname { get; set; }
		[NotMapped]
		public string? Semestername { get; set; }
	}
}
