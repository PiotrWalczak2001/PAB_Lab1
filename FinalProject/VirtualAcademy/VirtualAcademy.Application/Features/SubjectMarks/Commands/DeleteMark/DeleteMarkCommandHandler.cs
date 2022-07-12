using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.SubjectMarks.Commands.DeleteMark
{
    public class DeleteMarkCommandHandler : IRequestHandler<DeleteMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteMarkCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteMarkCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.SubjectMarkRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
