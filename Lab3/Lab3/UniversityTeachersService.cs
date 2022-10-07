using Lab3.Data;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    public class UniversityTeachersService
    {
        public static async Task<string> ReadTeachers(DbContextOptions<UniversityTeachersContext> options)
        {
            var db = new UniversityTeachersContext(options);
            var teachers = await db.UniversityTeachers.ToListAsync();
            return ToString(teachers);
        }

        public static string ToString(List<UniversityTeacher> universityTeachers)
        {
            List<string> teachersList = new List<string> { "First name&emsp;Last name&emsp;Patronymic name&emsp;Work place&emsp;Position name&emsp;First subject&emsp;Second subject&emsp;Position hourly rate&emsp;Read hours&emsp;Home address&emsp;Characteristics" };
            foreach (UniversityTeacher teacher in universityTeachers){
                teachersList.Add(String.Join("&emsp;&emsp;", new object[] {teacher.FirstName, teacher.LastName, teacher.PatronymicName, teacher.WorkPlace, teacher.PositionName, teacher.FirstSubjectName,
                    teacher.SecondSubjectName is null ? "-" : teacher.SecondSubjectName, teacher.PositionHourlyRate, teacher.CountReadHours, teacher.HomeAddress, teacher.Characteristics }));
            }
            return String.Join("</br>", teachersList);
        }
    }
}
