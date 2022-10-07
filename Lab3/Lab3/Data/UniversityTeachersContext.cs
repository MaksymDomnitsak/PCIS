using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.Metadata;
using Lab3.Models;

namespace Lab3.Data
{
    public partial class UniversityTeachersContext : DbContext
    {
        public UniversityTeachersContext()
        {
        }

        public UniversityTeachersContext(DbContextOptions<UniversityTeachersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<UniversityTeacher> UniversityTeachers { get; set; } = null!;
        public virtual DbSet<Workplace> Workplaces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseInMemoryDatabase(databaseName: "UniversityTeachers");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UniversityTeacher>(entity =>
            {
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
