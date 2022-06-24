using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Persistence.Repositories
{
    public class SemesterRepository : BaseRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Semester> GetActiveSemesterByStudentIdAsync(Guid studentId)
            => await _dbContext.Semesters.FirstOrDefaultAsync(x => x.StudentId == studentId && x.Status == SemesterStatusEnum.InProgress);
    }
}
