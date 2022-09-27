using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class UniversityTeacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PatronymicName { get; set; } = null!;
        public int WorkPlace { get; set; }
        public int PositionName { get; set; }
        public int FirstSubjectName { get; set; }
        public int? SecondSubjectName { get; set; }
        public int PositionHourlyRate { get; set; }
        public int CountReadHours { get; set; }
        public string HomeAddress { get; set; } = null!;
        public string Characteristics { get; set; } = null!;

        public virtual Subject FirstSubjectNameNavigation { get; set; } = null!;
        public virtual Position PositionNameNavigation { get; set; } = null!;
        public virtual Subject? SecondSubjectNameNavigation { get; set; }
        public virtual Workplace WorkPlaceNavigation { get; set; } = null!;
    }
}
