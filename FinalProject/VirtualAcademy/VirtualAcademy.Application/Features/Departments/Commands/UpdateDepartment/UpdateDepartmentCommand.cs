using MediatR;

namespace VirtualAcademy.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
