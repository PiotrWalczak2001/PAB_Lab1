using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Semesters.Commands.StartSemester
{
    public class StartSemesterCommandHandler : IRequestHandler<StartSemesterCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public StartSemesterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(StartSemesterCommand request, CancellationToken cancellationToken)
        {
            var activeSemester = await _unitOfWork.SemesterRepository.GetActiveSemesterByStudentIdAsync(request.StudentId);
            if (activeSemester != null)
                throw new Exception("Cant start new semester since another is already in progress.");

            Semester newSemester = new()
            {
                Id = Guid.NewGuid(),
                Status = SemesterStatusEnum.InProgress,
                SemesterType = request.SemesterType,
                StartDate = DateTime.Today,
                StudentId = request.StudentId,
                IsDeleted = false,
            };

            await _unitOfWork.SemesterRepository.AddAsync(newSemester);
            await _unitOfWork.SaveChangesAsync();

            return newSemester.Id;
        }
    }
}
