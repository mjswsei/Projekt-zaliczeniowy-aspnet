using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy_aspnet.Models.Entities;
using Projekt_zaliczeniowy_aspnet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projekt_zaliczeniowy_aspnet.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
		{
			public void Configure(EntityTypeBuilder<ApplicationUser> builder)
			{
				builder.Property(x => x.FirstName).HasMaxLength(255);
				builder.Property(x => x.LastName).HasMaxLength(255);
			}
		}

		public DbSet<Student> Students { get; set; }
	    public DbSet<Projekt_zaliczeniowy_aspnet.Models.Grade> Grade { get; set; } = default!;
	    public DbSet<Projekt_zaliczeniowy_aspnet.Models.Lecture> Lecture { get; set; } = default!;
	    public DbSet<Projekt_zaliczeniowy_aspnet.Models.Lecturer> Lecturer { get; set; } = default!;
	}
}
