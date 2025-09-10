using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
	public class DepartmentSemester
	{
		[Key]
		public int Id { get; set; }
		public int Depid { get; set; }
		public int Semesterid { get; set; }
	}
}
