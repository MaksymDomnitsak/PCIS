using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Lab2.Models
{
    public partial class UniversityTeachersContext : DbContext
    {

        public UniversityTeachersContext(DbContextOptions<UniversityTeachersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<UniversityTeacher> UniversityTeachers { get; set; } = null!;
        public virtual DbSet<Workplace> Workplaces { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(opti); //ConfigurationManager.ConnectionStrings["University"].ConnectionString
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UniversityTeacher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Characteristics).HasColumnType("text");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PatronymicName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.FirstSubjectNameNavigation)
                    .WithMany(p => p.UniversityTeacherFirstSubjectNameNavigations)
                    .HasForeignKey(d => d.FirstSubjectName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UniversityTeachers_fk2");

                entity.HasOne(d => d.PositionNameNavigation)
                    .WithMany(p => p.UniversityTeachers)
                    .HasForeignKey(d => d.PositionName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UniversityTeachers_fk1");

                entity.HasOne(d => d.SecondSubjectNameNavigation)
                    .WithMany(p => p.UniversityTeacherSecondSubjectNameNavigations)
                    .HasForeignKey(d => d.SecondSubjectName)
                    .HasConstraintName("UniversityTeachers_fk3");

                entity.HasOne(d => d.WorkPlaceNavigation)
                    .WithMany(p => p.UniversityTeachers)
                    .HasForeignKey(d => d.WorkPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UniversityTeachers_fk0");
            });

            modelBuilder.Entity<Workplace>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
