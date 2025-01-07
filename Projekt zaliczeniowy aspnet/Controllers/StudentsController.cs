using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekt_zaliczeniowy_aspnet.Data;
using Projekt_zaliczeniowy_aspnet.Models;
using Projekt_zaliczeniowy_aspnet.Models.Entities;

namespace Projekt_zaliczeniowy_aspnet.Controllers
{
	public class StudentsController : Controller
	{
		private readonly ApplicationDbContext dbContext;

		public StudentsController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		
		// Add
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		//
		public async Task<IActionResult> Add(AddStudentViewModel viewModel)
		{
			var student = new Student
			{
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				Address = viewModel.Address,
				IsRecievingUpdates = viewModel.IsRecievingUpdates
			};
			await dbContext.Students.AddAsync(student);
			await dbContext.SaveChangesAsync();
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var students = await dbContext.Students.ToListAsync();
			return View(students);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var student = await dbContext.Students.FindAsync(id);
			return View(student);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Student modelStudent)
		{
			var student = await dbContext.Students.FindAsync(modelStudent.Id);
			if (student is not null)
			{
				student.FirstName = modelStudent.FirstName;
				student.LastName = modelStudent.LastName;
				student.Email = modelStudent.Email;
				student.PhoneNumber = modelStudent.PhoneNumber;
				student.Address = modelStudent.Address;
				student.IsRecievingUpdates = modelStudent.IsRecievingUpdates;
				await dbContext.SaveChangesAsync();
			}
			return RedirectToAction("List", "Students");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Student viewModel)
		{
			var student = await dbContext.Students
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

			if (student is not null)
			{
				dbContext.Students.Remove(viewModel);
				await dbContext.SaveChangesAsync();
			}
			return RedirectToAction("List", "Students");
		}
	}
}
