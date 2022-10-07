using Lab3;
using Lab3.Data;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var optionsbuilder = new DbContextOptionsBuilder<UniversityTeachersContext>();

builder.Services.AddDbContext<UniversityTeachersContext>(options => optionsbuilder.UseInMemoryDatabase("UniversityTeachers"));

//string connectionString = builder.Configuration.GetConnectionString("University");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.UseStaticFiles();

app.MapGet(pattern: "/", async (HttpContext ctx) =>
{
    ctx.Response.Headers.ContentType = new Microsoft.Extensions.Primitives.StringValues("text/html; charset=UTF-8");
    await ctx.Response.WriteAsync(text: "<html><body><h1>Hello World!</h1><img src=\"images/universitylogo.jpg\" alt=\"logo\"></body></html>");
});
app.MapGet(pattern: "/universityteachers", async (HttpContext ctx) =>
{
    ctx.Response.Headers.ContentType = new Microsoft.Extensions.Primitives.StringValues("text/html; charset=UTF-8");
    await ctx.Response.WriteAsync(text: $"<html><body><img src=\"images/universitylogo.jpg\" alt=\"logo\"><p>{UniversityTeachersService.ReadTeachers(optionsbuilder.Options).Result}</p></body></html>");
});
app.Run();
