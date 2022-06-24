using MediatR;

namespace VirtualAcademy.Application.Features.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
