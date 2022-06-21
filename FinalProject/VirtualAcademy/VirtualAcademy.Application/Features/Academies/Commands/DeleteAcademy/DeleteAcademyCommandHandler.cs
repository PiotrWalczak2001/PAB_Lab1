using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Contracts.Services;

namespace VirtualAcademy.Application.Features.Academies.Commands.DeleteAcademy
{
    public class DeleteAcademyCommandHandler : IRequestHandler<DeleteAcademyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly ICourseService _courseService; 
        public DeleteAcademyCommandHandler(IUnitOfWork unitOfWork,
                                           IFileService fileService,
                                           ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _courseService = courseService;
        }
        public async Task<Unit> Handle(DeleteAcademyCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.AcademyId.ToString()))
                throw new ArgumentNullException(nameof(request.AcademyId));

            var academyToDelete = await _unitOfWork.AcademyRepository.GetByIdWithAllDetailsAsync(request.AcademyId); 

            if (academyToDelete == null)
                throw new ArgumentNullException(nameof(academyToDelete));
            
            await _fileService.DeleteFilesByApplicationId(academyToDelete.Id);
            await _courseService.DeleteAllCoursesByAcademyId(academyToDelete.Id);
            academyToDelete.Departments.ToList().ForEach(department => department.IsDeleted = true);

            academyToDelete.Students.ToList().ForEach(student => student.IsDeleted = true);
            academyToDelete.Employees.ToList().ForEach(employee => employee.IsDeleted = true);

            academyToDelete.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
