using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy_aspnet.Areas.Identity.Data;

namespace Projekt_zaliczeniowy_aspnet.Data;

public class Projekt_AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public Projekt_AuthDbContext(DbContextOptions<Projekt_AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
