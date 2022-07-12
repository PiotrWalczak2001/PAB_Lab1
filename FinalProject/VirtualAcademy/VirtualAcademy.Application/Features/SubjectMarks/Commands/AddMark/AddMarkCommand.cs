using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.SubjectMarks.Commands.AddMark
{
    public class AddMarkCommand : IRequest<Unit>
    {
        public double Value { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
        public Guid LecturerId { get; set; }
        public SubjectPassFormEnum FormOfPass { get; set; }
    }
}
