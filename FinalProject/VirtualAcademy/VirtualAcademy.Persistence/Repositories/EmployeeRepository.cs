using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Employee>> GetAllByAcademyId(Guid academyId)
            => await _dbContext.Employees
                               .Where(x => x.AcademyId == academyId)
                               .ToListAsync();
    }
}
