using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
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
        public string Name { get; set; } = string.Empty;

        [InverseProperty("PositionNameNavigation")]
        public virtual ICollection<UniversityTeacher> UniversityTeachers { get; set; }
    }
}
