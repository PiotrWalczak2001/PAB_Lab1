using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Employees.Models;

namespace VirtualAcademy.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeeInfoModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);

            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return new EmployeeInfoModel()
            {
                Id = employee.Id,
                AcademyId = employee.AcademyId,
                IsLecturer = employee.IsLecturer,
                AcademyEmail = employee.AcademyEmail,
                PhoneNumber = employee.PhoneNumber,
                FirstName = employee.FirstName,
                Surname = employee.Surname
            };
        }
    }
}
