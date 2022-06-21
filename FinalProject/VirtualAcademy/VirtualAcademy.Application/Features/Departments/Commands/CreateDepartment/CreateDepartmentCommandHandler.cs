using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentNullException(nameof(request.Name));

            if (string.IsNullOrEmpty(request.AcademyId.ToString()))
                throw new ArgumentNullException(nameof(request.AcademyId));

            // fast validation

            Department newDepartment = new()
            {
                Name = request.Name,
                AcademyId = request.AcademyId,
                Id = Guid.NewGuid()
            };

            await _unitOfWork.DepartmentRepository.AddAsync(newDepartment);
            await _unitOfWork.SaveChangesAsync();

            return newDepartment.Id;
        }
    }
}
