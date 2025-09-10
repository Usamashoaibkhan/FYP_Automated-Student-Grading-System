using Test2.Models;

namespace Test2.ViewModels
{
	public class TeacherVm
	{
		public List<Subject> Subjectlist { get; set; }
		public Teacher Teacher { get; set; }
		public Userlogin Userlogin { get; set; }
		public List<Department> Departmentlist { get; set; }
		public List<Semester> Semesterlist { get; set; }
	}
}
