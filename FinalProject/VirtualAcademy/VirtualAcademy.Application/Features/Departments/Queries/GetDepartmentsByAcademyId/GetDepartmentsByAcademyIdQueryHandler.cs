using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Departments.Models;

namespace VirtualAcademy.Application.Features.Departments.Queries.GetDepartmentsByAcademyId
{
    public class GetDepartmentsByAcademyIdQueryHandler : IRequestHandler<GetDepartmentsByAcademyIdQuery, IEnumerable<DepartmentInfoModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetDepartmentsByAcademyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DepartmentInfoModel>> Handle(GetDepartmentsByAcademyIdQuery request, CancellationToken cancellationToken)
        {
            var departmentsByAcademyId = (await _unitOfWork.DepartmentRepository.GetAllByAcademyIdAsync(request.AcademyId)).ToList();
            List<DepartmentInfoModel> departmentsToReturn = new();

            foreach (var department in departmentsByAcademyId)
            {
                departmentsToReturn.Add(new DepartmentInfoModel()
                {
                    Id = department.Id,
                    AcademyId = department.AcademyId,
                    Name = department.Name
                });
            }

            return departmentsToReturn;
        }
    }
}
