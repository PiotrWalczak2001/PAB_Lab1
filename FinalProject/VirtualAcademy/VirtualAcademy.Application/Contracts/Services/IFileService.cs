namespace VirtualAcademy.Application.Contracts.Services
{
    public interface IFileService
    {
        Task DeleteFilesByApplicationId(Guid applicationId);
    }
}
