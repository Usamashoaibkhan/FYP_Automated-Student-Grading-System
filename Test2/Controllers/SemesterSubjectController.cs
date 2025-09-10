using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Test2.Data;
using Test2.Data.Repository;
using Test2.Models;
using Test2.ViewModels;

namespace Test2.Controllers
{
	public class SemesterSubjectController : Controller
	{
		private readonly IRepository repository;
		private readonly ApplicationDbContext _context;
		public SemesterSubjectController(ApplicationDbContext applicationDbContext,IDbConnection cn)
		{
			_context = applicationDbContext;
			repository = new IRepository(cn); 
		}
		public IActionResult Index()
		{
			var list = repository.GetList<SemesterSubject>(
					"SELECT DISTINCT sm.*, d.Name AS Depname, s.Name AS Semestername " +
					"FROM SemesterSubject sm " +
					"INNER JOIN Department d ON d.Id = sm.Depid " +
					"INNER JOIN Semester s ON s.Id = sm.Semesterid")
				.GroupBy(e => new { e.Semesterid, e.Depid })
				.Select(g => g.First())
				.ToList(); 
			return View(list);
		}
		public IActionResult Create(SemesterSubject semester)
		{
			var Vm = new SemesterSubjectVm()
			{
				SemesterSubject = semester,
				Subjectlist = _context.Subject.ToList(),
				Departmentlist = _context.Department.ToList(),
				Semesterlist = _context.Semester.ToList()
			};
			return View(Vm);
		}
		public IActionResult Save(SemesterSubjectVm semesterSubjectVm)
		{
			string message;
			if (semesterSubjectVm.SemesterSubject.Id == 0)
			{
				foreach (var it in semesterSubjectVm.SemesterSubjectlist)
				{
					it.Semesterid = semesterSubjectVm.SemesterSubject.Semesterid;
					it.Depid = semesterSubjectVm.SemesterSubject.Depid;
					_context.SemesterSubject.Add(it);
				}

				message = "Data Saved Successfully!";
			}
			else
			{
				_context.Database.ExecuteSqlRaw("Delete from SemesterSubject where Semesterid='" + semesterSubjectVm.SemesterSubject.Semesterid + "' and Depid='" + semesterSubjectVm.SemesterSubject.Depid + "'");
				foreach (var it in semesterSubjectVm.SemesterSubjectlist)
				{
					it.Semesterid = semesterSubjectVm.SemesterSubject.Semesterid;
					it.Depid = semesterSubjectVm.SemesterSubject.Depid;
					_context.SemesterSubject.Add(it);
				}
				message = "Data Updated Successfully!";
			}
			_context.SaveChanges();
			TempData["Saved"] = message;
			return RedirectToAction("Create");
		}
		public IActionResult Edit(int id)
		{
			var dt = _context.SemesterSubject.FirstOrDefault(e => e.Id == id);

			var Vm = new SemesterSubjectVm()
			{
				SemesterSubject = dt,
				Subjectlist = _context.Subject.ToList(),
				Departmentlist = _context.Department.ToList(),
				Semesterlist = _context.Semester.ToList(),
				SemesterSubjectlist=_context.SemesterSubject.Where(e=>e.Depid==dt.Depid&&e.Semesterid==dt.Semesterid).ToList()
			};
			return View("Create", Vm);
		}
		public IActionResult Delete(int depid,int semesid)
		{
			_context.Database.ExecuteSqlRaw("Delete from SemesterSubject where Semesterid='" + semesid + "' and Depid='" + depid + "'");
			return RedirectToAction("Index");
		}
	}
}
