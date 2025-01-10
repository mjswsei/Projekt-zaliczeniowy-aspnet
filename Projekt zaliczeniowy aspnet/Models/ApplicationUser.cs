using Microsoft.AspNetCore.Identity;

namespace Projekt_zaliczeniowy_aspnet.Models
{
	public class ApplicationUser : IdentityUser
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }

	}
}
