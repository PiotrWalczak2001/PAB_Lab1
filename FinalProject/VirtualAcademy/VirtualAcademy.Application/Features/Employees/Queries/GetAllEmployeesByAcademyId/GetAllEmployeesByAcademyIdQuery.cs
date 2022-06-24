using MediatR;
using VirtualAcademy.Application.Features.Employees.Models;

namespace VirtualAcademy.Application.Features.Employees.Queries.GetAllEmployeesByAcademyId
{
    public class GetAllEmployeesByAcademyIdQuery : IRequest<IEnumerable<EmployeeListModel>>
    {
        public Guid AcademyId { get; set; }
    }
}
