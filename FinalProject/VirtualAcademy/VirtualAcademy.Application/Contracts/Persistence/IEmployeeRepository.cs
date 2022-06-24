using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllByAcademyId(Guid academyId);
    }
}
