using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy_aspnet.Data;
using Microsoft.AspNetCore.Identity;
using Projekt_zaliczeniowy_aspnet.Areas.Identity.Data;

namespace Projekt_zaliczeniowy_aspnet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//First DbContext
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal")));

			//Second DbContext
			builder.Services.AddDbContext<Projekt_AuthDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("Projekt_AuthDbContextConnection")));


			builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<Projekt_AuthDbContext>();

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}
