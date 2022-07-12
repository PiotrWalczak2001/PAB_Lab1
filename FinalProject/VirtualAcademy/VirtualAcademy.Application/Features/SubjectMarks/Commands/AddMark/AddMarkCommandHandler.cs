using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.SubjectMarks.Commands.AddMark
{
    public class AddMarkCommandHandler : IRequestHandler<AddMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddMarkCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(AddMarkCommand request, CancellationToken cancellationToken)
        {
            SubjectMark subjectMarkToAdd = new()
            {
                Value = request.Value,
                FormOfPass = request.FormOfPass,
                SemesterId = request.SemesterId,
                SubjectId = request.SubjectId,
                DateOfGetMark = DateTime.Now,
                LecturerId = request.LecturerId
            };

            await _unitOfWork.SubjectMarkRepository.AddAsync(subjectMarkToAdd);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
