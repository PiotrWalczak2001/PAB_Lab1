using MediatR;

namespace VirtualAcademy.Application.Features.Academies.Commands.CreateAcademy
{
    public class CreateAcademyCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string Description { get; set; }
        public Guid? ImageId { get; set; }
    }
}
