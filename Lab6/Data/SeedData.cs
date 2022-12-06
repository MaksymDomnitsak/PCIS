using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityTeachersContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UniversityTeachersContext>>()))
            {
                if (context.UniversityTeachers.Any())
                {
                    return;
                }

                context.Positions.AddRange(new Position { Name = "Декан" },new Position { Name = "Завідувач кафедрою"},
                    new Position { Name = "Професор" }, new Position { Name = "Доцент" }, new Position { Name = "Викладач" }); 
                /*context.Workplaces.Add(new Workplace { Name = "ЧНУ ім. Юрія Федьковича" });
                context.Subjects.AddRange(new Subject { Name = "Математичний аналіз" }, new Subject { Name = "Лінійна алгебра" }, new Subject { Name = "Програмування" },
                    new Subject { Name = "Числові методи" }, new Subject { Name = "Аналітична геометрія" });
                context.UniversityTeachers.AddRange(new UniversityTeacher
                {
                    FirstName = "Никитченко",
                    LastName = "Олег",
                    PatronymicName = "Олександрович",
                    WorkPlace = 1,
                    PositionName = 1,
                    FirstSubjectName = 3,
                    SecondSubjectName = 4,
                    PositionHourlyRate = 25,
                    CountReadHours = 12,
                    HomeAddress = "м. Чернівці, вул. Воробкевича, буд. 12",
                    Characteristics = "Викладач - декан"
                }, new UniversityTeacher
                {
                    FirstName = "Олекса",
                    LastName = "Ірина",
                    PatronymicName = "Дмитрівна",
                    WorkPlace = 1,
                    PositionName = 5,
                    FirstSubjectName = 2,
                    SecondSubjectName = null,
                    PositionHourlyRate = 15,
                    CountReadHours = 8,
                    HomeAddress = "м. Чернівці, вул. Коцюбинського, буд. 3",
                    Characteristics = "Викладач-початківець"
                }, new UniversityTeacher { 
                    FirstName="Латер",
                    LastName="Михайло",
                    PatronymicName="Сергійович",
                    WorkPlace=1,
                    PositionName=3,
                    FirstSubjectName=2,
                    SecondSubjectName=5,
                    PositionHourlyRate=22,
                    CountReadHours=12,
                    HomeAddress="м.Івано - Франківськ, вул.Шевченка, буд. 25",
                    Characteristics="Викладач - професіонал"
                }, new UniversityTeacher
                {
                    FirstName="Мариніна", 
                    LastName="Олена", 
                    PatronymicName="Миколаївна",
                    WorkPlace=1,
                    PositionName=2,
                    FirstSubjectName=1,
                    SecondSubjectName=4,
                    PositionHourlyRate=20,
                    CountReadHours=15,
                    HomeAddress="м.Чернівці, вул.Небесної Сотні, буд. 4",
                    Characteristics="Викладач - завідувач"
                }, new UniversityTeacher
                {
                    FirstName = "Наталін",
                    LastName = "Андрій",
                    PatronymicName = "Кирилович",
                    WorkPlace = 1,
                    PositionName = 4,
                    FirstSubjectName = 3,
                    SecondSubjectName = null,
                    PositionHourlyRate = 12,
                    CountReadHours = 8,
                    HomeAddress = "м.Чернівці, вул.Героїв Майдану, буд. 6",
                    Characteristics = "Просто викладач"
                }
                    );*/
                context.SaveChanges();
            }
        }
    }
}

