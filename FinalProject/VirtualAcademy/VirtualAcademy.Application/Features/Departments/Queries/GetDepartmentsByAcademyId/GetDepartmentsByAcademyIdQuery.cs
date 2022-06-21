using MediatR;
using VirtualAcademy.Application.Features.Departments.Models;

namespace VirtualAcademy.Application.Features.Departments.Queries.GetDepartmentsByAcademyId
{
    public class GetDepartmentsByAcademyIdQuery : IRequest<IEnumerable<DepartmentInfoModel>>
    {
        public Guid AcademyId { get; set; }
    }
}
