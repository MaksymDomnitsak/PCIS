using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class Subject
    {
        public Subject()
        {
            UniversityTeacherFirstSubjectNameNavigations = new HashSet<UniversityTeacher>();
            UniversityTeacherSecondSubjectNameNavigations = new HashSet<UniversityTeacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<UniversityTeacher> UniversityTeacherFirstSubjectNameNavigations { get; set; }
        public virtual ICollection<UniversityTeacher> UniversityTeacherSecondSubjectNameNavigations { get; set; }
    }
}
