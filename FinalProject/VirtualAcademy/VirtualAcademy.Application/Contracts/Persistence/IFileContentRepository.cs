using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IFileContentRepository : IBaseRepository<FileContent>
    {
        Task<FileContent> GetFileContentByFileIdAsync(Guid fileId);
    }
}
