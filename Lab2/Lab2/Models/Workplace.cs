using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class Workplace
    {
        public Workplace()
        {
            UniversityTeachers = new HashSet<UniversityTeacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
