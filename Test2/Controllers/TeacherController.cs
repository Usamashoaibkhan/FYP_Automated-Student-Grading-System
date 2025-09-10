using Microsoft.AspNetCore.Mvc;
using System.Data;
using Test2.Data;
using Test2.Data.Repository;
using Test2.Models;
using Test2.ViewModels;

namespace Test2.Controllers
{
	public class TeacherController : Controller
	{
		private readonly IRepository _repo;
		private readonly ApplicationDbContext _context;
		public TeacherController(ApplicationDbContext c,IDbConnection db)
		{
			_context = c;
			_repo = new IRepository(db);
		}
		public IActionResult Index()
		{
			var list = _context.Teacher.OrderByDescending(e => e.Id).ToList();
			return View(list);
		}
		public IActionResult Create(Teacher Teacher)
		{
			var Vm = new TeacherVm()
			{
				Teacher = Teacher,
				Subjectlist = _context.Subject.ToList(),
				Departmentlist = _context.Department.ToList(),
				Semesterlist = _context.Semester.ToList(),
			};
			return View(Vm);
		}
		[HttpPost]
		public IActionResult Save(TeacherVm Vm)
		{
			string message;
			if (Vm.Teacher.Id == 0)
			{
				Vm.Teacher.Roleid = 2;
				_context.Teacher.Add(Vm.Teacher);
				_context.SaveChanges();
				Vm.Teacher.Id = _context.Teacher.Max(e => e.Id);
				_context.Userlogin.Add(new Userlogin()
				{
					Username = Vm.Userlogin.Username,
					Password = Vm.Userlogin.Password,
					Roleid = 2,
					Userid = Vm.Teacher.Id
				});
				message = "Data Saved Successfully!";
			}
			else
			{
				var dt = _context.Teacher.FirstOrDefault(e => e.Id == Vm.Teacher.Id);
				if (dt != null)
				{
					dt.Name = Vm.Teacher.Name;
					dt.Address = Vm.Teacher.Address;
					dt.Email = Vm.Teacher.Email;
					dt.Phone = Vm.Teacher.Phone;
					dt.Subjectid = Vm.Teacher.Subjectid;
					dt.Departmentid = Vm.Teacher.Departmentid;
					dt.Semesterid = Vm.Teacher.Semesterid;
					dt.Cnic = Vm.Teacher.Cnic;
				}
				var user = _context.Userlogin.FirstOrDefault(e => e.Userid == Vm.Teacher.Id);
				if (user != null)
				{
					user.Username = Vm.Userlogin.Username;
					user.Password = Vm.Userlogin.Password;
				}
				message = "Data Updated Successfully!";
			}
			_context.SaveChanges();
			TempData["Saved"] = message;
			return RedirectToAction("Create");
		}
		public IActionResult Edit(int Id)
		{
			var sub = _context.Teacher.FirstOrDefault(e => e.Id == Id);
			var Vm = new TeacherVm()
			{
				Teacher = sub,
				Subjectlist = _context.Subject.ToList(),
				Departmentlist = _context.Department.ToList(),
				Semesterlist = _context.Semester.ToList(),
				Userlogin = _context.Userlogin.FirstOrDefault(e => e.Userid == sub.Id)
			};
			return View("Create", Vm);
		}
		public IActionResult Delete(int Id)
		{
			var user = _context.Userlogin.FirstOrDefault(e => e.Userid == Id);
			if (user != null)
			{
				_context.Userlogin.Remove(user);
			}
			var del = _context.Teacher.FirstOrDefault(e => e.Id == Id);
			_context.Teacher.Remove(del);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Profile()
		{
			Teacher Teacher = new Teacher();
			Userlogin userlogin = new Userlogin();
			var roleIdStr = HttpContext.Session.GetString("roleid");
			var userIdStr = HttpContext.Session.GetString("userid");
			if (!string.IsNullOrEmpty(roleIdStr) && int.TryParse(roleIdStr, out int roleId) && roleId == 2)
			{
				if (!string.IsNullOrEmpty(userIdStr) && int.TryParse(userIdStr, out int userId))
				{
					//Teacher = _context.Teacher.FirstOrDefault(e => e.Id == userId) ?? new Teacher();
					Teacher = _repo.GetModelData<Teacher>("select t.* ,d.Name as Depname,sub.Name as Subjectname,s.Name as Semestername from  Teacher t Left join Department d on d.Id =t.Departmentid Left join Semester s on s.Id=t.Semesterid Left join Subject sub on sub.Id=t.Subjectid Where t.Id='"+ userId + "'") ?? new Teacher();
					userlogin = _context.Userlogin.FirstOrDefault(w => w.Userid == userId&&w.Roleid==2)??new Userlogin();
				}
			}
			else
			{
				return Unauthorized();
			}
			var Vm = new TeacherVm()
			{
				Teacher=Teacher,
				Userlogin= userlogin
			};
			return View(Vm);
		}
		public IActionResult UpdateProfile(TeacherVm teacherVm)
		{
			var dta = _context.Teacher.FirstOrDefault(e => e.Id == teacherVm.Teacher.Id);
			if (dta == null)
				return NotFound();

			dta.Name = teacherVm.Teacher.Name;
			dta.Address = teacherVm.Teacher.Address;
			dta.Cnic = teacherVm.Teacher.Cnic;
			dta.Email = teacherVm.Teacher.Email;
			dta.Phone = teacherVm.Teacher.Phone;
			var user = _context.Userlogin.FirstOrDefault(e => e.Userid == teacherVm.Teacher.Id && e.Roleid == 2);
			if (user != null)
			{
				user.Password = teacherVm.Userlogin.Password;
				user.Username = teacherVm.Userlogin.Username;
			}
			_context.SaveChanges();
			TempData["Saved"]= "Data Updated Successfully!";
			return RedirectToAction("Profile");
		}
		public IActionResult AllStudent()
		{
			var roleIdStr = HttpContext.Session.GetString("roleid");
			if (!string.IsNullOrEmpty(roleIdStr) && int.TryParse(roleIdStr, out int roleId) && roleId == 2)
			{
				var userIdStr = HttpContext.Session.GetString("userid");
				if (!string.IsNullOrEmpty(userIdStr) && int.TryParse(userIdStr, out int userId))
				{
					var teacher = _context.Teacher.FirstOrDefault(e => e.Id == userId);
					if (teacher != null)
					{
						//var students = _context.Student.Where(s => s.Depid == teacher.Departmentid && s.Semesterid == teacher.Semesterid).ToList();
						return View(_repo.GetList<Student>("Select s.*,d.Name as Depname ,sm.Name as Semestername from Student s Left Join Department d on d.Id=s.Depid Left Join Semester sm on sm.Id=s.Semesterid WHere s.Semesterid='"+teacher.Semesterid+"' and s.Depid='" + teacher.Departmentid+ "' Order BY s.Id desc"));
					}
				}
			}
			return Unauthorized();
		}

		public IActionResult UploadDocument()
		{
			return View();
		}




	}
}
