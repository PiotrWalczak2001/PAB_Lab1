using MediatR;

namespace VirtualAcademy.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public Guid DepartmentId { get; set; }
    }
}
