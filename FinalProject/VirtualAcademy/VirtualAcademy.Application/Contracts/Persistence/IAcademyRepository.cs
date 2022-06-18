using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IAcademyRepository : IBaseRepository<Academy>
    {
        Task<Academy> GetByIdWithCoursesAsync(Guid id);
        Task<Academy> GetByIdWithAllDetailsAsync(Guid id);
    }
}
