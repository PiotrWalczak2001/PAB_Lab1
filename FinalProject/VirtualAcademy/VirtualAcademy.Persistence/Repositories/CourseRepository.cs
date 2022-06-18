using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Course>> GetAllByAcademyIdAsync(Guid academyId)
            => await _dbContext.Courses
                               .Where(x => x.AcademyId == academyId)
                               .ToListAsync();

        public async Task<Course> GetWithSubjectsByIdAsync(Guid id)
            => await _dbContext.Courses
                               .Include(x => x.Subjects)
                               .FirstOrDefaultAsync(x => x.Id == id);
    }
}
