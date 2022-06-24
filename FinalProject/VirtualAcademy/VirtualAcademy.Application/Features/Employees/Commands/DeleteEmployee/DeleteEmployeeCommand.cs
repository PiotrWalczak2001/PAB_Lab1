using MediatR;

namespace VirtualAcademy.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public Guid EmployeeId { get; set; }
    }
}
