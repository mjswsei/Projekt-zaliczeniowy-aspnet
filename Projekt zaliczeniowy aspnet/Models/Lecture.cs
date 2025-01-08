namespace Projekt_zaliczeniowy_aspnet.Models
{
	public class Lecture
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public bool IsEndingWithExam { get; set; }
		public Lecturer Lecturer { get; set; }
		public Lecture()
		{

		}

	}
}
