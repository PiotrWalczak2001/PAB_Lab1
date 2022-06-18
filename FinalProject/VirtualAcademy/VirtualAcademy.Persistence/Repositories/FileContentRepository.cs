using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Persistence.Repositories
{
    public class FileContentRepository : BaseRepository<FileContent>, IFileContentRepository
    {
        public FileContentRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<FileContent> GetFileContentByFileIdAsync(Guid fileId)
            => await _dbContext.FileContents.FirstOrDefaultAsync(x => x.FileId == fileId);
    }
}
