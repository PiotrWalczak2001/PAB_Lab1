using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> GetAllByAcademyIdAsync(Guid academyId);
        Task<Course> GetWithSubjectsByIdAsync(Guid id);
    }
}
