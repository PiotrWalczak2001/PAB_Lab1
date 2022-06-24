using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSubjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subjectToUpdate = await _unitOfWork.SubjectRepository.GetByIdAsync(request.Id);

            if (subjectToUpdate == null)
                throw new ArgumentNullException(nameof(subjectToUpdate));

            subjectToUpdate.CourseId = request.CourseId;
            subjectToUpdate.FormOfFinalSubjectPass = request.FormOfFinalSubjectPass;
            subjectToUpdate.LecturerId = request.LecturerId;
            subjectToUpdate.Name = request.Name;
            subjectToUpdate.SubjectType = request.SubjectType;

            _unitOfWork.SubjectRepository.Update(subjectToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return subjectToUpdate.Id;
        }
    }
}
