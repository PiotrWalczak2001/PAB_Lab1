using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Department>> GetAllByAcademyIdAsync(Guid academyId)
            => await _dbContext.Departments
                               .Where(x => x.AcademyId == academyId)
                               .ToListAsync();
    }
}
