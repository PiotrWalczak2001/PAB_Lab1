using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;
        public IAcademyRepository AcademyRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public IFileRepository FileRepository { get; private set; }
        public IFileContentRepository FileContentRepository { get; private set; }
        public ISubjectRepository SubjectRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public ISubjectMarkRepository SubjectMarkRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public ILecturerRepository LecturerRepository { get; private set; }
        public ISemesterRepository SemesterRepository { get; private set;}
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            AcademyRepository = new AcademyRepository(_dbContext);
            CourseRepository = new CourseRepository(_dbContext);
            FileRepository = new FileRepository(_dbContext);
            FileContentRepository = new FileContentRepository(_dbContext);
            SubjectRepository = new SubjectRepository(_dbContext);
            StudentRepository = new StudentRepository(_dbContext);
            SubjectMarkRepository = new SubjectMarkRepository(_dbContext);
            DepartmentRepository = new DepartmentRepository(_dbContext);
            EmployeeRepository = new EmployeeRepository(_dbContext);
            LecturerRepository = new LecturerRepository(_dbContext);
            SemesterRepository = new SemesterRepository(_dbContext);
        }

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
