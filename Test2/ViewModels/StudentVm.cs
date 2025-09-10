using Test2.Models;

namespace Test2.ViewModels
{
	public class StudentVm
	{
		public List<Subject> Subjectlist { get; set; }
		public List<Department> Departmentlist { get; set; }
		public List<DepartmentSemester> DepartmentSemesterlist { get; set; }
		public List<SemesterSubject> SemesterSubjectlist { get; set; }
		public List<Semester> Semesterlist { get; set; }

		public Student Student { get; set; }
		public Userlogin Userlogin { get; set; }
	}
}
