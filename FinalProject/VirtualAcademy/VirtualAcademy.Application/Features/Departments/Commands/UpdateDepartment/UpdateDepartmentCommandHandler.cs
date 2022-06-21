using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentNullException(nameof(request.Name));

            if (string.IsNullOrEmpty(request.Id.ToString()))
                throw new ArgumentNullException(nameof(request.Id));

            // fast validation later I ll use fluent validation

            var departmentToUpdate = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.Id);

            if (departmentToUpdate == null)
                throw new ArgumentNullException(nameof(departmentToUpdate));

            departmentToUpdate.Name = request.Name;
            
            _unitOfWork.DepartmentRepository.Update(departmentToUpdate);
            await _unitOfWork.SaveChangesAsync();
            
            return departmentToUpdate.Id;
        }
    }
}
