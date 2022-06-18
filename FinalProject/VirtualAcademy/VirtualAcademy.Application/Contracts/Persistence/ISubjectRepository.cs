using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<IEnumerable<Subject>> GetLectureTypeSubjectsByCourseIdAsync(Guid courseId);
        Task<IEnumerable<Subject>> GetAllSubjectsWithMarksByCourseIdAsync(Guid courseId);
    }
}
