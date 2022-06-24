using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSubjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject newSubject = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SubjectType = request.SubjectType,
                LecturerId = request.LecturerId,
                CourseId = request.CourseId,
                FormOfFinalSubjectPass = request.FormOfFinalSubjectPass
            };
            await _unitOfWork.SubjectRepository.AddAsync(newSubject);
            await _unitOfWork.SaveChangesAsync();

            return newSubject.Id;
        }
    }
}
