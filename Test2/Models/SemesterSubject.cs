using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
	public class SemesterSubject
	{
		[Key]
		public int Id { get; set; }
		public int Semesterid { get; set; }
		public int Subjectid { get; set; }
		public int Depid { get; set; }
		public string? Subjectname { get; set; }

		[NotMapped]
		public string? Depname { get;set; }
		[NotMapped]
		public string? Semestername { get; set; }
	}
}
