namespace EntityFrameworkTests.Models;

public partial class WeekJournal
{
    public int Id { get; set; }

    public int JournalTeacherId { get; set; }

    public int JournalAcademSubId { get; set; }

    public DateTime StartLessonDt { get; set; }

    public DateTime EndLessonDt { get; set; }

    public virtual AcademySubject JournalAcademSub { get; set; } = null!;

    public virtual Teacher JournalTeacher { get; set; } = null!;
}
