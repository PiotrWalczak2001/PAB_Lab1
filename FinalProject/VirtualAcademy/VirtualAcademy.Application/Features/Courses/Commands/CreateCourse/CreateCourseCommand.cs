using MediatR;

namespace VirtualAcademy.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public Guid AcademyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
