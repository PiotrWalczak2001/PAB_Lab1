using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Contracts.Services;

namespace VirtualAcademy.Application.Features.Files.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteFilesByApplicationId(Guid applicationId)
        {
            var allFiles = (await _unitOfWork.FileRepository.GetAllFilesByAcademyIdAsync(applicationId)).ToList();
            foreach (var file in allFiles)
            {
                await _unitOfWork.FileContentRepository.DeleteByIdAsync(file.FileContentId);
                file.IsDeleted = true;
            }
            _unitOfWork.FileRepository.UpdateRange(allFiles);
        }
    }
}
