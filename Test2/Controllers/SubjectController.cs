using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
	public class SubjectController : Controller
	{
		private readonly ApplicationDbContext _context;
		public SubjectController(ApplicationDbContext c)
		{
			_context = c;
		}
		public IActionResult Index()
		{
			var list = _context.Subject.OrderByDescending(e => e.Id).ToList();
			return View(list);
		}
		public IActionResult Create(Subject subject)
		{
			return View(subject);
		}
		[HttpPost]
		public IActionResult Save(Subject subject)
		{
			string message;
			if (subject.Id == 0)
			{
				_context.Subject.Add(subject);
				message = "Data Saved Successfully!";
			}
			else
			{
				var sub = _context.Subject.FirstOrDefault(e => e.Id == subject.Id);
				if (sub != null)
				{
					sub.Name = subject.Name;
				}
				message = "Data Saved Successfully!";
			}
			_context.SaveChanges();
			TempData["Saved"] = message;
			return RedirectToAction("Create");
		}
		public IActionResult Edit(int Id)
		{
			var sub = _context.Subject.FirstOrDefault(e => e.Id == Id);

			return View("Create", sub);
		}
		public IActionResult Delete(int Id)
		{
			var del = _context.Subject.FirstOrDefault(e => e.Id == Id);
			_context.Subject.Remove(del);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
