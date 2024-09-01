using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterDetailsInCoreDataFirst.Models;

public partial class MasterDetailsInCoreDbfirstContext : DbContext
{
    public MasterDetailsInCoreDbfirstContext()
    {
    }

    public MasterDetailsInCoreDbfirstContext(DbContextOptions<MasterDetailsInCoreDbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MasterDetailsInCoreDBFirst; \nTrusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE91A8BF437924");

            entity.ToTable("Applicant");

            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Qualification).HasMaxLength(50);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__Experien__2F4E344949409CBB");

            entity.ToTable("Experience");

            entity.Property(e => e.Designation).HasMaxLength(100);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Experienc__Appli__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
