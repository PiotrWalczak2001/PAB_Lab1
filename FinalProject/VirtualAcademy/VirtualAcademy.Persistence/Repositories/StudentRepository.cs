using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Student>> GetAllByAcademyIdAsync(Guid academyId)
            => await _dbContext.Students
                               .Where(x => x.AcademyId == academyId)
                               .ToListAsync();

        public async Task<IEnumerable<Student>> GetAllByCourseIdAsync(Guid CourseId)
            => await _dbContext.Students
                               .Where(x => x.CourseId == CourseId)
                               .ToListAsync();
    }
}
