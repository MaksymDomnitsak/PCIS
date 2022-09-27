using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

string connectionString = config.GetConnectionString("University");
var optionsBuilder = new DbContextOptionsBuilder<UniversityTeachersContext>();
var options = optionsBuilder
    .UseSqlServer(connectionString)
    .Options;
var db = new UniversityTeachersContext(options);

Console.WriteLine("Querying for a teachers");
var teachers = from t in db.UniversityTeachers
               join p in db.Positions on t.PositionName equals p.Id
               join w in db.Workplaces on t.WorkPlace equals w.Id
               join f in db.Subjects on t.FirstSubjectName equals f.Id
               join s in db.Subjects on t.SecondSubjectName equals s.Id
               select new {FirstName = t.FirstName,LastName = t.LastName,PatronymicName = t.PatronymicName,WorkPlace = w.Name,PositionName = p.Name,
               FirstSubjectName = f.Name,SecondSubjectName = s.Name,PositionHourlyRate = t.PositionHourlyRate, CountReadHours=t.CountReadHours,
               HomeAddress=t.HomeAddress,Characteristics=t.Characteristics};
foreach (var teacher in teachers)
{
    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}",
     teacher.FirstName, teacher.LastName, teacher.PatronymicName, teacher.WorkPlace, teacher.PositionName,
        teacher.FirstSubjectName,teacher.SecondSubjectName, teacher.PositionHourlyRate, teacher.CountReadHours, teacher.HomeAddress, teacher.Characteristics);
}
Console.ReadLine();

