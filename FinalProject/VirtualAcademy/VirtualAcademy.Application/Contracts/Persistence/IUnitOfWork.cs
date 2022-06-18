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
        Task SaveChangesAsync();
        void Dispose();
    }
}
