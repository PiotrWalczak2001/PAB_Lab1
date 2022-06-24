using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSubjectCommandHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subjectToDelete = await _unitOfWork.SubjectRepository.GetByIdAsync(request.Id);

            if (subjectToDelete == null)
                throw new ArgumentNullException(nameof(subjectToDelete));

            subjectToDelete.IsDeleted = true;

            _unitOfWork.SubjectRepository.Update(subjectToDelete);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
