using MediatR;

namespace VirtualAcademy.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public Guid AcademyId { get; set; }
        public string Name { get; set; }
    }
}
