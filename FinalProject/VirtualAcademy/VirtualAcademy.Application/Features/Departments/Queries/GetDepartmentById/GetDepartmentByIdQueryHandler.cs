using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Departments.Models;

namespace VirtualAcademy.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetDepartmentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DepartmentInfoModel> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.Id);

            if (department == null)
                throw new ArgumentNullException(nameof(department));

            DepartmentInfoModel departmentDto = new()
            {
                Id = department.Id,
                Name = department.Name,
                AcademyId = department.AcademyId
            };

            return departmentDto;
        }
    }
}
