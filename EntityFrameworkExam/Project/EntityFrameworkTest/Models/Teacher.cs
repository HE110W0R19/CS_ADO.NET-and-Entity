namespace EntityFrameworkTests.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual ICollection<WeekJournal> WeekJournals { get; set; } = new List<WeekJournal>();
}
