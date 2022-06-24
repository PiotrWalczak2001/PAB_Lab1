using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface ILecturerRepository : IBaseRepository<Lecturer>
    {
        Task<IEnumerable<Lecturer>> GetAllByAcademyIdAsync(Guid academyId);
    }
}
