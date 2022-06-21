using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.DepartmentId.ToString()))
                throw new ArgumentNullException(nameof(request.DepartmentId));

            await _unitOfWork.DepartmentRepository.DeleteByIdAsync(request.DepartmentId);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
