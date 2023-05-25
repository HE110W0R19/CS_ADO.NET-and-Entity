namespace EntityFrameworkTests.Models;

public partial class AcademySubject
{
    public int Id { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<WeekJournal> WeekJournals { get; set; } = new List<WeekJournal>();
}
