using Test2.Models;

namespace Test2.ViewModels
{
	public class RegistrationVm
	{
		public Student Student { get; set; }
		public Teacher Teacher { get; set; }
		public Userlogin Userlogin { get; set; }
		public List<Subject> Subjectlist { get; set; }
		public List<Department> Departmentlist { get; set; }
		public bool Usertype { get; set; } = true;
	}
}
