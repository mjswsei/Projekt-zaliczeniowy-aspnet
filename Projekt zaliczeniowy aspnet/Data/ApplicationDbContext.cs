using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy_aspnet.Models.Entities;

namespace Projekt_zaliczeniowy_aspnet.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<Student> Students { get; set; }
	}
}
