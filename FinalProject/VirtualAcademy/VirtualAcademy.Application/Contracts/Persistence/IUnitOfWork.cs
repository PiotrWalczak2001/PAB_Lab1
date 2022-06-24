namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IAcademyRepository AcademyRepository { get; }
        ICourseRepository CourseRepository { get; }
        IFileRepository FileRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IFileContentRepository FileContentRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectMarkRepository SubjectMarkRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        ILecturerRepository LecturerRepository { get; }
        ISemesterRepository SemesterRepository { get; }
        Task SaveChangesAsync();
        void Dispose();
    }
}
