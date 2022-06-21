using MediatR;
using VirtualAcademy.Application.Features.Departments.Models;

namespace VirtualAcademy.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentInfoModel>
    {
        public Guid Id { get; set; }
    }
}
