using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.SubjectMarks.Commands.UpdateMark
{
    public class UpdateMarkCommandHandler : IRequestHandler<UpdateMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMarkCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateMarkCommand request, CancellationToken cancellationToken)
        {
            var markToChange = await _unitOfWork.SubjectMarkRepository.GetByIdAsync(request.Id);
            markToChange.LecturerId = request.LecturerId;
            markToChange.Value = request.Value;
            markToChange.FormOfPass = request.FormOfPass;
            markToChange.SemesterId = request.SemesterId;
            markToChange.SubjectId = request.SubjectId;

            _unitOfWork.SubjectMarkRepository.Update(markToChange);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
