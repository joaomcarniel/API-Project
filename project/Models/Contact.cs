namespace project.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int ContactStatus { get; set; }

    public string Telephone { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? CreationDate { get; set; }
}
