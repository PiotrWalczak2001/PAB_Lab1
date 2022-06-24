using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Employees.Models;

namespace VirtualAcademy.Application.Features.Employees.Queries.GetAllEmployeesByAcademyId
{
    public class GetAllEmployeesByAcademyIdQueryHandler : IRequestHandler<GetAllEmployeesByAcademyIdQuery, IEnumerable<EmployeeListModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllEmployeesByAcademyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmployeeListModel>> Handle(GetAllEmployeesByAcademyIdQuery request, CancellationToken cancellationToken)
        {
            List<EmployeeListModel> employeeModels = new();
            var employees = await _unitOfWork.EmployeeRepository.GetAllByAcademyId(request.AcademyId);

            foreach (var employee in employees)
            {
                employeeModels.Add(new EmployeeListModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    Surname = employee.Surname,
                    AcademyId = employee.AcademyId,
                    IsLecturer = employee.IsLecturer
                });
            }
            return employeeModels;
        }
    }
}
