using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IFileRepository : IBaseRepository<File>
    {
        Task<File> GetFileWithContentByIdAsync(Guid fileId);
        Task<IEnumerable<File>> GetAllFilesByAcademyIdAsync(Guid academyId);
    }

}
