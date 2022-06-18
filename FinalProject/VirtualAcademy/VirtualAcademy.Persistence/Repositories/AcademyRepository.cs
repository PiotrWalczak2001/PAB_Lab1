using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class AcademyRepository : BaseRepository<Academy>, IAcademyRepository
    {
        public AcademyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Academy> GetByIdWithCoursesAsync(Guid id)
            => await _dbContext.Academies
                               .Include(a => a.Courses)
                               .ThenInclude(c => c.Subjects)
                               .FirstOrDefaultAsync(a => a.Id == id);
        public async Task<Academy> GetByIdWithAllDetailsAsync(Guid id)
            => await _dbContext.Academies
                               .Include(a => a.Courses)
                               .ThenInclude(c => c.Subjects)
                               .Include(a => a.Students)
                               .Include(a => a.Employees)
                               .Include(a => a.Files)
                               .Include(a => a.Departments)
                               .FirstOrDefaultAsync(a => a.Id == id);
    }
}
