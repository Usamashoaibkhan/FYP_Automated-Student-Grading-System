using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
	public class DepartmentController : Controller
	{

		private readonly ApplicationDbContext _context;
		public DepartmentController(ApplicationDbContext c)
		{
			_context = c;
		}
		public IActionResult Index()
		{
			var list = _context.Department.OrderByDescending(e => e.Id).ToList();
			return View(list);
		}
		public IActionResult Create(Department Department)
		{
			return View(Department);
		}
		[HttpPost]
		public IActionResult Save(Department Department)
		{
			string message;
			if (Department.Id == 0)
			{
				_context.Department.Add(Department);
				message = "Data Saved Successfully!";
			}
			else
			{
				var sub = _context.Department.FirstOrDefault(e => e.Id == Department.Id);
				if (sub != null)
				{
					sub.Name = Department.Name;
				}
				message = "Data Updated Successfully!";
			}
			_context.SaveChanges();
			TempData["Saved"] = message;
			return RedirectToAction("Create");
		}
		public IActionResult Edit(int Id)
		{
			var sub = _context.Department.FirstOrDefault(e => e.Id == Id);
			if (sub == null)
				return NoContent();

			return View("Create", sub);
		}
		public IActionResult Delete(int Id)
		{
			var del = _context.Department.FirstOrDefault(e => e.Id == Id);
			if (del != null)
			{
				_context.Department.Remove(del);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}
	}
}
