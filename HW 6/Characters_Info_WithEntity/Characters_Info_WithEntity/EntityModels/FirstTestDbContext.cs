using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Characters_Info_WithEntity.EntityModels;

public partial class FirstTestDbContext : DbContext
{
    public FirstTestDbContext()
    {
    }

    public FirstTestDbContext(DbContextOptions<FirstTestDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterClassBuild> CharacterClassBuilds { get; set; }

    public virtual DbSet<CharactersClass> CharactersClasses { get; set; }

    public virtual DbSet<CharactersExpirience> CharactersExpiriences { get; set; }

    public virtual DbSet<Expirience> Expiriences { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("host=db4free.net;username=anonim;password=anonim228;database=first_test_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CharacterClassId, "CharacterClassId");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.CharacterClass).WithMany(p => p.Characters)
                .HasForeignKey(d => d.CharacterClassId)
                .HasConstraintName("Characters_ibfk_1");
        });

        modelBuilder.Entity<CharacterClassBuild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CharacterClassBuild");

            entity.HasIndex(e => e.CharacterClassId, "CharacterClassId");

            entity.HasIndex(e => e.SpellId, "SpellId");

            entity.HasOne(d => d.CharacterClass).WithMany(p => p.CharacterClassBuilds)
                .HasForeignKey(d => d.CharacterClassId)
                .HasConstraintName("CharacterClassBuild_ibfk_1");

            entity.HasOne(d => d.Spell).WithMany(p => p.CharacterClassBuilds)
                .HasForeignKey(d => d.SpellId)
                .HasConstraintName("CharacterClassBuild_ibfk_2");
        });

        modelBuilder.Entity<CharactersClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CharactersClass");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CharactersExpirience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CharactersExpirience");

            entity.HasIndex(e => e.CharactersId, "CharactersId");

            entity.HasIndex(e => e.ExpirienceId, "ExpirienceId");

            entity.HasOne(d => d.Characters).WithMany(p => p.CharactersExpiriences)
                .HasForeignKey(d => d.CharactersId)
                .HasConstraintName("CharactersExpirience_ibfk_1");

            entity.HasOne(d => d.ExpirienceNavigation).WithMany(p => p.CharactersExpiriences)
                .HasForeignKey(d => d.ExpirienceId)
                .HasConstraintName("CharactersExpirience_ibfk_2");
        });

        modelBuilder.Entity<Expirience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Expirience");

            entity.HasIndex(e => e.CurrentLevel, "CurrentLevel").IsUnique();
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Spell");

            entity.HasIndex(e => e.ExpirienceId, "ExpirienceId");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Expirience).WithMany(p => p.Spells)
                .HasForeignKey(d => d.ExpirienceId)
                .HasConstraintName("Spell_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
