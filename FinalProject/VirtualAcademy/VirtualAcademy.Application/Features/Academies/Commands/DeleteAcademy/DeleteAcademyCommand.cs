using MediatR;

namespace VirtualAcademy.Application.Features.Academies.Commands.DeleteAcademy
{
    public class DeleteAcademyCommand : IRequest<Unit>
    {
        public Guid AcademyId { get; set; }
    }
}
