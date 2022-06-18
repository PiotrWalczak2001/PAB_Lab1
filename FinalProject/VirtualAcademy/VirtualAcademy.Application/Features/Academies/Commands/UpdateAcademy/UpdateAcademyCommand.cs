using MediatR;

namespace VirtualAcademy.Application.Features.Academies.Commands.UpdateAcademy
{
    public class UpdateAcademyCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string Description { get; set; }
        public Guid? ImageId { get; set; }
    }
}
