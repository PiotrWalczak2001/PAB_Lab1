using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Domain.Entities;
using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Persistence
{
    public class AppDbContext : IdentityDbContext
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Academy>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Course>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<File>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Group>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Semester>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Subject>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => x.StillWorking == true && x.IsDeleted == false);
            modelBuilder.Entity<Student>().HasQueryFilter(x => x.IsStudying == true && x.IsDeleted == false);

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
                                              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "bb352f3f-dfd1-4c23-a879-84a8885107c6",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "29f2dfb3-e391-4b46-9c1b-dfd360bdc40f",
                Name = "Lecturer",
                NormalizedName = "LECTURER"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "9c0a5871-fd62-46f6-9aa0-6253ddf8436a",
                Name = "Student",
                NormalizedName = "STUDENT"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "41955396-834b-4ee6-901a-fc9dfbd0b92d",
                Name = "User",
                NormalizedName = "USER"
            });


            var adminUser = new IdentityUser
            {
                Id = "d2420772-683a-40ad-a5b7-9bf93cccc1df",
                UserName = "Test Admin",
                NormalizedUserName = "TEST ADMIN",
                Email = "testadmin@mail.com",
                NormalizedEmail = "TESTADMIN@MAIL.COM",
                EmailConfirmed = true,
            };
            var adminPassword = new PasswordHasher<IdentityUser>();
            var adminHashed = adminPassword.HashPassword(adminUser, "Admin!12");
            adminUser.PasswordHash = adminHashed;

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);


            var lecturerUser = new IdentityUser
            {
                Id = "1737574a-e41b-4f2d-b288-da7c2323b4e6",
                UserName = "Test Lecturer",
                NormalizedUserName = "TEST LECTURER",
                Email = "testlecturer@mail.com",
                NormalizedEmail = "TESTLECTURER@MAIL.COM",
                EmailConfirmed = true,
            };
            var lecturerPassword = new PasswordHasher<IdentityUser>();
            var lecturerHashed = lecturerPassword.HashPassword(lecturerUser, "Lecturer!12");
            lecturerUser.PasswordHash = lecturerHashed;

            modelBuilder.Entity<IdentityUser>().HasData(lecturerUser);


            var studentUser = new IdentityUser
            {
                Id = "dcf71a67-2e23-4582-a461-bf856c1133e3",
                UserName = "Test Student",
                NormalizedUserName = "TEST STUDENT",
                Email = "teststudent@mail.com",
                NormalizedEmail = "TESTSTUDENT@MAIL.COM",
                EmailConfirmed = true,
            };
            var studentPassword = new PasswordHasher<IdentityUser>();
            var studentHashed = studentPassword.HashPassword(studentUser, "Student!12");
            studentUser.PasswordHash = studentHashed;

            modelBuilder.Entity<IdentityUser>().HasData(studentUser);


            var normalUser = new IdentityUser
            {
                Id = "63f3fc0b-ee4a-453e-802b-7e6b554d798f",
                UserName = "Test User",
                NormalizedUserName = "TEST USER",
                Email = "testuser@mail.com",
                NormalizedEmail = "TESTUSER@MAIL.COM",
                EmailConfirmed = true,
            };
            var normalPassword = new PasswordHasher<IdentityUser>();
            var normalHashed = normalPassword.HashPassword(normalUser, "User!12");
            normalUser.PasswordHash = normalHashed;

            modelBuilder.Entity<IdentityUser>().HasData(normalUser);



            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "bb352f3f-dfd1-4c23-a879-84a8885107c6",
                UserId = "d2420772-683a-40ad-a5b7-9bf93cccc1df"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "29f2dfb3-e391-4b46-9c1b-dfd360bdc40f",
                UserId = "1737574a-e41b-4f2d-b288-da7c2323b4e6"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "9c0a5871-fd62-46f6-9aa0-6253ddf8436a",
                UserId = "dcf71a67-2e23-4582-a461-bf856c1133e3"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "41955396-834b-4ee6-901a-fc9dfbd0b92d",
                UserId = "63f3fc0b-ee4a-453e-802b-7e6b554d798f"
            });
        }
    }
}
