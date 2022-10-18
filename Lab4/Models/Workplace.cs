using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Models
{
    public partial class Workplace
    {
        public Workplace()
        {
            UniversityTeachers = new HashSet<UniversityTeacher>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty("WorkPlaceNavigation")]
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
