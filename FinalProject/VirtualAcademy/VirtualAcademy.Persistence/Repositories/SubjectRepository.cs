using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Persistence.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Subject>> GetLectureTypeSubjectsByCourseIdAsync(Guid courseId)
            => await _dbContext.Subjects
                               .Where(x => x.CourseId == courseId && x.SubjectType == SubjectTypeEnum.Lecture)
                               .ToListAsync();

        public async Task<IEnumerable<Subject>> GetAllSubjectsWithMarksByCourseIdAsync(Guid courseId)
            => await _dbContext.Subjects
                               .Include(x => x.Marks)
                               .Where(x => x.CourseId == courseId)
                               .ToListAsync();
    }
}
