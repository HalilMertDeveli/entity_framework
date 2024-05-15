using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

UserContext context = new UserContext();
var manager = new Manager { ManagerId = 1, ManagerName = "Hasan Taskin" };
await context.Manager.AddAsync(manager);
await context.SaveChangesAsync();
Console.WriteLine("Manager added ");
namespace SchoolDatabase
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            
        }
        
    }
}

public class User
{
    public int UserId { get; set; }
    public  string UserName { get; set; }
    public  string UserLastName { get; set; }
    public  ICollection<Lesson> UserLesson { get; set; }
}
public class Lesson
{
    public int LessonId { get; set; }
    public  string LessonName { get; set; }
    public  LessonTeacher LessonTeacher { get; set; }
}
public class LessonTeacher
{
    [Key]
    public int TeacherId { get; set; }
    public  string TeacherName { get; set; }
    public  string TeacherLastName { get; set; }

}
public class Manager
{
    public int ManagerId { get; set; }
    public string ManagerName { get; set; }
}
public class UserContext : DbContext
{
    public DbSet<User> UserDbSet { get; set; }
    public DbSet<Lesson> LessonDbSet { get; set; }
    public DbSet<LessonTeacher> LessonTeacherDbSet { get; set; }
    public DbSet<Manager> Manager { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=localhost;Database=UserDb;Trusted_Connection=True;TrustServerCertificate=True");

    }
}