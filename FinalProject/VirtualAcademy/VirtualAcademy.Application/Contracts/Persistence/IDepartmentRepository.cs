using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllByAcademyIdAsync(Guid academyId);
    }
}
