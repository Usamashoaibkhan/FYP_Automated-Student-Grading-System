using Test2.Models;

namespace Test2.ViewModels
{
	public class SemesterSubjectVm
	{
		public SemesterSubject SemesterSubject { get;set; }
		public List<Semester> Semesterlist { get; set; }
		public List<Department> Departmentlist { get; set; }
		public List<Subject> Subjectlist { get; set; }
		public List<SemesterSubject> SemesterSubjectlist { get; set; }
	}
}
