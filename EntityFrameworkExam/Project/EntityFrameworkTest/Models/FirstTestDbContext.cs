using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTests.Models;

public partial class EntityTestDbContext : DbContext
{
    public EntityTestDbContext()
    {
    }

    public EntityTestDbContext(DbContextOptions<EntityTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademySubject> AcademySubjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<WeekJournal> WeekJournals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("host=db4free.net;username=anonim;password=anonim228;database=first_test_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AcademySubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("AcademySubject");

            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Teacher");

            entity.Property(e => e.FirstName).HasMaxLength(32);
            entity.Property(e => e.LastName).HasMaxLength(32);
            entity.Property(e => e.Patronymic).HasMaxLength(32);
        });

        modelBuilder.Entity<WeekJournal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("WeekJournal");

            entity.HasIndex(e => e.JournalAcademSubId, "JournalAcademSubId");

            entity.HasIndex(e => e.JournalTeacherId, "JournalTeacherId");

            entity.Property(e => e.EndLessonDt)
                .HasColumnType("datetime")
                .HasColumnName("EndLessonDT");
            entity.Property(e => e.StartLessonDt)
                .HasColumnType("datetime")
                .HasColumnName("StartLessonDT");

            entity.HasOne(d => d.JournalAcademSub).WithMany(p => p.WeekJournals)
                .HasForeignKey(d => d.JournalAcademSubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WeekJournal_ibfk_2");

            entity.HasOne(d => d.JournalTeacher).WithMany(p => p.WeekJournals)
                .HasForeignKey(d => d.JournalTeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WeekJournal_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
