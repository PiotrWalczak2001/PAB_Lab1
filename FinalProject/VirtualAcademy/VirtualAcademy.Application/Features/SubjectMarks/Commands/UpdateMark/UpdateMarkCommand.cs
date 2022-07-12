using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.SubjectMarks.Commands.UpdateMark
{
    public class UpdateMarkCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
        public Guid LecturerId { get; set; }
        public SubjectPassFormEnum FormOfPass { get; set; }
    }
}
