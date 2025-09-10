using Microsoft.AspNetCore.Mvc;
using System.Data;
using Test2.Data;
using Test2.Data.Repository;
using Test2.Models;
using Test2.ViewModels;

namespace Test2.Controllers
{
	public class StudentController : Controller
	{
		private readonly IRepository _repo;
		private readonly ApplicationDbContext _context;
		public StudentController(ApplicationDbContext c,IDbConnection d)
		{
			_context = c;
			_repo = new IRepository(d);
		}
		public IActionResult Index()
		{
			var list = _context.Student.OrderByDescending(e => e.Id).ToList();
			return View(list);
		}
		public IActionResult Create(Student Student)
		{
			var Vm = new StudentVm()
			{
				Student = Student,
				Departmentlist = _context.Department.ToList(),
				Semesterlist = _context.Semester.ToList(),
			};
			return View(Vm);
		}
		[HttpPost]
		public IActionResult Save(StudentVm Vm)
		{
			string message;
			if (Vm.Student.Id == 0)
			{
				Vm.Student.Roleid = 3;
				_context.Student.Add(Vm.Student);
				_context.SaveChanges();
				Vm.Student.Id = _context.Student.Max(e => e.Id);
				_context.Userlogin.Add(new Userlogin()
				{
					Username = Vm.Userlogin.Username,
					Password = Vm.Userlogin.Password,
					Roleid = 3,
					Userid = Vm.Student.Id
				});
				message = "Data Saved Successfully!";
			}
			else
			{
				var dt = _context.Student.FirstOrDefault(e => e.Id == Vm.Student.Id);
				if (dt != null)
				{
					dt.Name = Vm.Student.Name;
					dt.Address = Vm.Student.Address;
					dt.Email = Vm.Student.Email;
					dt.Phone = Vm.Student.Phone;
					dt.Depid = Vm.Student.Depid;
					dt.Semesterid = Vm.Student.Semesterid;
				}
				var user = _context.Userlogin.FirstOrDefault(e => e.Userid == Vm.Student.Id);
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
			var sub = _context.Student.FirstOrDefault(e => e.Id == Id);
			if (sub == null)
				return NotFound();

			var Vm = new StudentVm()
			{
				Student = sub,
				Departmentlist = _context.Department.ToList(),
				Semesterlist = _context.Semester.ToList(),
				Userlogin = _context.Userlogin.FirstOrDefault(e => e.Userid == sub.Id) ?? new Userlogin()
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
			var del = _context.Student.FirstOrDefault(e => e.Id == Id);
			if (del != null)
			{
				_context.Student.Remove(del);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}
		public IActionResult Profile()
		{
			Userlogin userlogin = new Userlogin();
			Student student = new Student();
			var roleIdStr = HttpContext.Session.GetString("roleid");
			var userIdStr = HttpContext.Session.GetString("userid");
			if (!string.IsNullOrEmpty(roleIdStr) && int.TryParse(roleIdStr, out int roleId) && roleId == 3)
			{
				if (!string.IsNullOrEmpty(userIdStr) && int.TryParse(userIdStr, out int userId))
				{
					student = _repo.GetModelData<Student>("Select s.*,d.Name as Depname ,sm.Name as Semestername  from Student s Left Join Department d on d.Id=s.Depid left Join Semester sm on sm.Id=s.Semesterid Where s.Id='"+ userId + "'") ?? new Student();
					userlogin = _context.Userlogin.FirstOrDefault(w => w.Userid == userId && w.Roleid == 3) ?? new Userlogin();
				}
			}
			else
			{
				return Unauthorized();
			}
			var Vm = new StudentVm()
			{
				Userlogin = userlogin,
				Student = student
			};
			return View(Vm);
		}
		public IActionResult UpdateProfile(StudentVm studentVm)
		{
			var dta = _context.Student.FirstOrDefault(e => e.Id == studentVm.Student.Id);
			if (dta == null)
				return NotFound();

			dta.Name = studentVm.Student.Name;
			dta.Address = studentVm.Student.Address;
			dta.Cnic = studentVm.Student.Cnic;
			dta.Email = studentVm.Student.Email;
			dta.Phone = studentVm.Student.Phone;
			var user = _context.Userlogin.FirstOrDefault(e => e.Userid == studentVm.Student.Id && e.Roleid == 3);
			if (user != null)
			{
				user.Password = studentVm.Userlogin.Password;
				user.Username = studentVm.Userlogin.Username;
			}
			_context.SaveChanges();
			TempData["Saved"] = "Data Updated Successfully!";
			return RedirectToAction("Profile");
		}

	}
}
