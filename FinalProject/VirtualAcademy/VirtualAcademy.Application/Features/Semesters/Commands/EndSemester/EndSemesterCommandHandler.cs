using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Semesters.Commands.EndSemester
{
    public class EndSemesterCommandHandler : IRequestHandler<EndSemesterCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EndSemesterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(EndSemesterCommand request, CancellationToken cancellationToken)
        {
            var activeSemester = await _unitOfWork.SemesterRepository.GetByIdAsync(request.SemesterId);

            if (activeSemester == null)
                throw new ArgumentNullException(nameof(activeSemester));

            if (request.SemesterStatus != SemesterStatusEnum.InProgress)
            {
                activeSemester.Status = request.SemesterStatus;
                _unitOfWork.SemesterRepository.Update(activeSemester);
                await _unitOfWork.SaveChangesAsync();

                return Unit.Value;
            }
            else
                throw new Exception("Bad semester status");
        }
    }
}
