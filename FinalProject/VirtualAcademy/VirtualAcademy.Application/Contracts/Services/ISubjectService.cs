namespace VirtualAcademy.Application.Contracts.Services
{
    public interface ISubjectService
    {
        Task DeleteAllSubjectsWithMarksByCourseId(Guid courseId);
    }
}
