using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public partial class Position
    {
        public Position()
        {
            UniversityTeachers = new HashSet<UniversityTeacher>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty("PositionNameNavigation")]
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
