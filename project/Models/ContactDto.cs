namespace project.Models
{
    public class ContactDto
    {
        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public int ContactStatus { get; set; }

        public string Telephone { get; set; } = null!;

        public string? Email { get; set; }
    }
}
