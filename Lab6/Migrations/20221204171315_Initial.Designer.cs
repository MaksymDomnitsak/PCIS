// <auto-generated />
using System;
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab6.Migrations
{
    [DbContext(typeof(UniversityTeachersContext))]
    [Migration("20221204171315_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab6.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Lab6.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Lab6.Models.UniversityTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Characteristics")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CountReadHours")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("FirstSubjectName")
                        .HasColumnType("int");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PatronymicName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("PositionHourlyRate")
                        .HasColumnType("int");

                    b.Property<int>("PositionName")
                        .HasColumnType("int");

                    b.Property<int?>("SecondSubjectName")
                        .HasColumnType("int");

                    b.Property<int>("WorkPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstSubjectName");

                    b.HasIndex("PositionName");

                    b.HasIndex("SecondSubjectName");

                    b.HasIndex("WorkPlace");

                    b.ToTable("UniversityTeachers");
                });

            modelBuilder.Entity("Lab6.Models.Workplace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Workplaces");
                });

            modelBuilder.Entity("Lab6.Models.UniversityTeacher", b =>
                {
                    b.HasOne("Lab6.Models.Subject", "FirstSubjectNameNavigation")
                        .WithMany("UniversityTeacherFirstSubjectNameNavigations")
                        .HasForeignKey("FirstSubjectName")
                        .IsRequired()
                        .HasConstraintName("UniversityTeachers_fk2");

                    b.HasOne("Lab6.Models.Position", "PositionNameNavigation")
                        .WithMany("UniversityTeachers")
                        .HasForeignKey("PositionName")
                        .IsRequired()
                        .HasConstraintName("UniversityTeachers_fk1");

                    b.HasOne("Lab6.Models.Subject", "SecondSubjectNameNavigation")
                        .WithMany("UniversityTeacherSecondSubjectNameNavigations")
                        .HasForeignKey("SecondSubjectName")
                        .HasConstraintName("UniversityTeachers_fk3");

                    b.HasOne("Lab6.Models.Workplace", "WorkPlaceNavigation")
                        .WithMany("UniversityTeachers")
                        .HasForeignKey("WorkPlace")
                        .IsRequired()
                        .HasConstraintName("UniversityTeachers_fk0");

                    b.Navigation("FirstSubjectNameNavigation");

                    b.Navigation("PositionNameNavigation");

                    b.Navigation("SecondSubjectNameNavigation");

                    b.Navigation("WorkPlaceNavigation");
                });

            modelBuilder.Entity("Lab6.Models.Position", b =>
                {
                    b.Navigation("UniversityTeachers");
                });

            modelBuilder.Entity("Lab6.Models.Subject", b =>
                {
                    b.Navigation("UniversityTeacherFirstSubjectNameNavigations");

                    b.Navigation("UniversityTeacherSecondSubjectNameNavigations");
                });

            modelBuilder.Entity("Lab6.Models.Workplace", b =>
                {
                    b.Navigation("UniversityTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
