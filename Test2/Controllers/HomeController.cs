using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Models;
using Test2.ViewModels;

namespace Test2.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
		{
			_logger = logger;
			_context = applicationDbContext;
		}

		public IActionResult Index()
		{
			Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
			Response.Headers["Pragma"] = "no-cache";
			Response.Headers["Expires"] = "0";

			var roleids = HttpContext.Session.GetString("roleid");
			if (string.IsNullOrEmpty(roleids) || !int.TryParse(roleids, out int roleid))
			{
				return RedirectToAction("SessionExpired", "Home");
			}

			if (roleid == 1)
			{
				ViewBag.totalstudent = _context.Student.Count();
				ViewBag.totalteacher = _context.Teacher.Count();
				ViewBag.totaldepartment = _context.Department.Count();
			}

			return View();
		}

		public IActionResult SessionExpired()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(Login login)
		{
			try
			{
				var user = _context.Userlogin.FirstOrDefault(e => e.Username == login.Username && e.Password == login.Password);
				if (user == null)
				{
					ViewBag.LogginError = "Invalid Username Or Password!";
					return View("Login");
				}
				HttpContext.Session.SetString("roleid", user.Roleid.ToString());
				HttpContext.Session.SetString("userid", user.Userid.ToString());





				return RedirectToAction("Index", "Home");
			}
			catch (Exception e)
			{
				return NotFound(e.Message.ToString());
			}
		}
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}
		public IActionResult Register()
		{
			var vm = new RegistrationVm()
			{
				Subjectlist = _context.Subject.ToList(),
				Departmentlist = _context.Department.ToList(),
				Student = new Student(),
				Teacher = new Teacher(),
			};
			return View(vm);
		}
		[HttpPost]
		public IActionResult Register(RegistrationVm Vm)
		{
			int roleId = Vm.Usertype ? 3 : 2;
			int userId;

			if (Vm.Usertype)
			{
				Vm.Student.Roleid = roleId;
				_context.Student.Add(Vm.Student);
				_context.SaveChanges();
				userId = Vm.Student.Id;
			}
			else
			{
				var teacher = new Teacher
				{
					Name = Vm.Student.Name,
					Email = Vm.Student.Email,
					Phone = Vm.Student.Phone,
					Roleid = roleId
				};
				_context.Teacher.Add(teacher);
				_context.SaveChanges();
				userId = teacher.Id;
			}

			var userLogin = new Userlogin
			{
				Userid = userId,
				Username = Vm.Userlogin.Username,
				Password = Vm.Userlogin.Password,
				Roleid = roleId
			};
			_context.Userlogin.Add(userLogin);
			_context.SaveChanges();
			return RedirectToAction("Login");
		}
	}
}
