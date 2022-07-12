using MediatR;

namespace VirtualAcademy.Application.Features.SubjectMarks.Commands.DeleteMark
{
    public class DeleteMarkCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
