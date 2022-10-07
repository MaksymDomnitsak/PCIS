using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public partial class UniversityTeacher
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(32)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [StringLength(32)]
        [Unicode(false)]
        public string PatronymicName { get; set; } = null!;
        public int WorkPlace { get; set; }
        public int PositionName { get; set; }
        public int FirstSubjectName { get; set; }
        public int? SecondSubjectName { get; set; }
        public int PositionHourlyRate { get; set; }
        public int CountReadHours { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string HomeAddress { get; set; } = null!;
        [Column(TypeName = "text")]
        public string Characteristics { get; set; } = null!;

        [ForeignKey("FirstSubjectName")]
        [InverseProperty("UniversityTeacherFirstSubjectNameNavigations")]
        public Subject FirstSubjectNameNavigation { get; set; } = null!;
        [ForeignKey("PositionName")]
        [InverseProperty("UniversityTeachers")]
        public Position PositionNameNavigation { get; set; } = null!;
        [ForeignKey("SecondSubjectName")]
        [InverseProperty("UniversityTeacherSecondSubjectNameNavigations")]
        public Subject? SecondSubjectNameNavigation { get; set; }
        [ForeignKey("WorkPlace")]
        [InverseProperty("UniversityTeachers")]
        public Workplace WorkPlaceNavigation { get; set; } = null!;
    }
}
