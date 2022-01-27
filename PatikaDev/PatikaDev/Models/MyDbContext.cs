using Microsoft.EntityFrameworkCore;

namespace PatikaDev.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseDate> CourseDates { get; set; }
        public DbSet<CourseAbsence> CourseAbsences { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }

}
