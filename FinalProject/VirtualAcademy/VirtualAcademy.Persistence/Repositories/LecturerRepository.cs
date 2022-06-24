using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class LecturerRepository : BaseRepository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Lecturer>> GetAllByAcademyIdAsync(Guid academyId)
            => await _dbContext.Lecturers.Where(x => x.AcademyId == academyId).ToListAsync();
    }
}
