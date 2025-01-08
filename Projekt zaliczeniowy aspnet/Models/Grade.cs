namespace Projekt_zaliczeniowy_aspnet.Models
{
	public class Grade
	{
		public Guid Id { get; set; }
		public int Value { get; set; }
		public string? Description { get; set; }

		public Grade()
		{
			
		}

	}
}
