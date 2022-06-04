using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Domain.Entities;
using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Academy> Academies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileContent> FileContents { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<StudentNote> StudentNotes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<SubjectMark> SubjectMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academy>().HasQueryFilter(x => x.IsDeleted != false);
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted != false);
            modelBuilder.Entity<Course>().HasQueryFilter(x => x.IsDeleted != false);
            modelBuilder.Entity<File>().HasQueryFilter(x => x.IsDeleted != false);
            modelBuilder.Entity<Group>().HasQueryFilter(x => x.IsDeleted != false);
            modelBuilder.Entity<Semester>().HasQueryFilter(x => x.IsDeleted != false);
            modelBuilder.Entity<Subject>().HasQueryFilter(x => x.IsDeleted != false);

            modelBuilder.Entity<Academy>().HasMany(a => a.Departments)
                                          .WithOne(d => d.Academy)
                                          .HasForeignKey(d => d.AcademyId);

            modelBuilder.Entity<Academy>().HasMany(a => a.Courses)
                                         .WithOne(c => c.Academy)
                                         .HasForeignKey(c => c.AcademyId);

            modelBuilder.Entity<Academy>().HasMany(a => a.Employees)
                                         .WithOne(e => e.Academy)
                                         .HasForeignKey(e => e.AcademyId);

            modelBuilder.Entity<Academy>().HasMany(a => a.Students)
                                         .WithOne(s => s.Academy)
                                         .HasForeignKey(s => s.AcademyId);

            modelBuilder.Entity<Academy>().HasMany(a => a.Files)
                                         .WithOne(s => s.Academy)
                                         .HasForeignKey(s => s.AcademyId);

            modelBuilder.Entity<Department>().HasMany(d => d.Lecturers)
                                             .WithOne(l => l.Department)
                                             .HasForeignKey(l => l.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>().HasMany(c => c.Subjects)
                                         .WithOne(s => s.Course)
                                         .HasForeignKey(l => l.CourseId);

            modelBuilder.Entity<Course>().HasMany(c => c.Students)
                                         .WithOne(s => s.Course)
                                         .HasForeignKey(s => s.CourseId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<File>().HasOne(f => f.Content)
                                       .WithOne(c => c.File)
                                       .HasForeignKey<FileContent>(c => c.FileId);

            modelBuilder.Entity<StudentGroup>().HasKey(sg => new { sg.StudentId, sg.GroupId });

            modelBuilder.Entity<StudentGroup>().HasOne(sg => sg.Student)
                                               .WithMany(s => s.StudentGroups)
                                               .HasForeignKey(sg => sg.StudentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentGroup>().HasOne(sg => sg.Group)
                                               .WithMany(s => s.StudentGroups)
                                               .HasForeignKey(sg => sg.GroupId);

            modelBuilder.Entity<SubjectGroup>().HasKey(sg => new { sg.SubjectId, sg.GroupId });

            modelBuilder.Entity<SubjectGroup>().HasOne(sg => sg.Group)
                                               .WithMany(g => g.SubjectGroups)
                                               .HasForeignKey(sg => sg.GroupId);

            modelBuilder.Entity<SubjectGroup>().HasOne(sg => sg.Subject)
                                               .WithMany(s => s.SubjectGroups)
                                               .HasForeignKey(sg => sg.SubjectId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>().HasOne(g => g.Course)
                                        .WithMany(c => c.Groups)
                                        .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<Lecturer>().HasMany(l => l.Subjects)
                                           .WithOne(s => s.Lecturer)
                                           .HasForeignKey(s => s.LecturerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lecturer>().HasMany(l => l.Marks)
                                           .WithOne(m => m.Lecturer)
                                           .HasForeignKey(s => s.LecturerId);

            modelBuilder.Entity<Lecturer>().HasMany(l => l.StudentNotes)
                                           .WithOne(s => s.Lecturer)
                                           .HasForeignKey(s => s.LecturerId);

            modelBuilder.Entity<Semester>().HasOne(s => s.Student)
                                           .WithMany(st => st.Semesters)
                                           .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Semester>().HasMany(s => s.Marks)
                                           .WithOne(m => m.Semester)
                                           .HasForeignKey(m => m.SemesterId);

            modelBuilder.Entity<Student>().HasMany(s => s.StudentNotes)
                                          .WithOne(n => n.Student)
                                          .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubjectMark>().HasOne(sm => sm.Subject)
                                              .WithMany(s => s.Marks)
                                              .HasForeignKey(s => s.SubjectId)
                                              .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
