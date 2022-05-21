using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Academy> Academies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<FileContent> FileContents { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentNote> StudentNotes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectMark> SubjectMarks { get; set; }
    }
}
