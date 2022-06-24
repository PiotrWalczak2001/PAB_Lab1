using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Semesters.Commands.StartSemester
{
    public class StartSemesterCommand : IRequest<Guid>
    {
        public Guid StudentId { get; set; }
        public SemesterTypeEnum SemesterType { get; set; }
    }
}
