using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SubjectPassFormEnum FormOfFinalSubjectPass { get; set; }
        public SubjectTypeEnum SubjectType { get; set; }
        public Guid CourseId { get; set; }
        public Guid LecturerId { get; set; }
    }
}
