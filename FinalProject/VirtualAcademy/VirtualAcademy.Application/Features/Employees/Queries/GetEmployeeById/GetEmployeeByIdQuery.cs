using MediatR;
using VirtualAcademy.Application.Features.Employees.Models;

namespace VirtualAcademy.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeInfoModel>
    {
        public Guid Id { get; set; }
    }
}
