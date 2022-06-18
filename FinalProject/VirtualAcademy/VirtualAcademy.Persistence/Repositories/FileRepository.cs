using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Persistence.Repositories
{
    public class FileRepository : BaseRepository<File>, IFileRepository
    {
        public FileRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<File> GetFileWithContentByIdAsync(Guid fileId)
            => await _dbContext.Files
                               .Include(f => f.Content)
                               .FirstOrDefaultAsync(f => f.Id == fileId);

        public async Task<IEnumerable<File>> GetAllFilesByAcademyIdAsync(Guid academyId)
            => await _dbContext.Files
                               .Where(x => x.AcademyId == academyId)
                               .ToListAsync();
    }
}
