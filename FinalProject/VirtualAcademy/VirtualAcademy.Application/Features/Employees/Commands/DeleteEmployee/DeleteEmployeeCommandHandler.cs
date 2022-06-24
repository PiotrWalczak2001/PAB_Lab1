using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.EmployeeId);
            if (employeeToDelete == null)
                throw new ArgumentNullException(nameof(employeeToDelete));

            employeeToDelete.StillWorking = false;
            employeeToDelete.IsDeleted = true;
            employeeToDelete.EndOfWorkDate = DateTime.Today;

            _unitOfWork.EmployeeRepository.Update(employeeToDelete);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
