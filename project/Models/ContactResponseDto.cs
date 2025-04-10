namespace project.Models
{
    public class ContactResponseDtoList
    {
        public int TotalCount { get; set; } = 0;
        public int Offset { get; set; } = 0;
        public List<ContactResponseDto> Contacts { get; set; } = new List<ContactResponseDto>();
    }
    public class ContactResponseDto
    {
        public int ContactId { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public int ContactStatus { get; set; }

        public string Telephone { get; set; } = null!;

        public string? Email { get; set; }
    }
}
