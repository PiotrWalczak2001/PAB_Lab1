using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class SubjectMarkRepository : BaseRepository<SubjectMark>, ISubjectMarkRepository
    {
        public SubjectMarkRepository(AppDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
