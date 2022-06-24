using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Semesters.Commands.EndSemester
{
    public class EndSemesterCommand : IRequest<Unit>
    {
        public Guid SemesterId { get; set; }
        public SemesterStatusEnum SemesterStatus { get; set; }
    }
}
