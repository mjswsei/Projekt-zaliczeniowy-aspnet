using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy_aspnet.Models.Entities;
using Projekt_zaliczeniowy_aspnet.Models;

namespace Projekt_zaliczeniowy_aspnet.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<Student> Students { get; set; }
	    public DbSet<Projekt_zaliczeniowy_aspnet.Models.Grade> Grade { get; set; } = default!;
	    public DbSet<Projekt_zaliczeniowy_aspnet.Models.Lecture> Lecture { get; set; } = default!;
	    public DbSet<Projekt_zaliczeniowy_aspnet.Models.Lecturer> Lecturer { get; set; } = default!;
	}
}
