using MediatR;

namespace VirtualAcademy.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
