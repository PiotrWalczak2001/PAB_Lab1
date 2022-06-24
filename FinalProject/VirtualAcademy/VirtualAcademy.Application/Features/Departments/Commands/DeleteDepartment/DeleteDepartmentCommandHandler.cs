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
            var departmentToDelete = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentId);
            if (departmentToDelete == null)
                throw new ArgumentNullException(nameof(departmentToDelete));

            departmentToDelete.IsDeleted = true;

            _unitOfWork.DepartmentRepository.Update(departmentToDelete);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
