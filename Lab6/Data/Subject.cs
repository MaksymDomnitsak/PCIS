using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public partial class Subject
    {
        public Subject()
        {
            UniversityTeacherFirstSubjectNameNavigations = new HashSet<UniversityTeacher>();
            UniversityTeacherSecondSubjectNameNavigations = new HashSet<UniversityTeacher>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty("FirstSubjectNameNavigation")]
        public virtual ICollection<UniversityTeacher> UniversityTeacherFirstSubjectNameNavigations { get; set; }
        [InverseProperty("SecondSubjectNameNavigation")]
        public virtual ICollection<UniversityTeacher> UniversityTeacherSecondSubjectNameNavigations { get; set; }
    }
}
