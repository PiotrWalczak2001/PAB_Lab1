using MediatR;

namespace VirtualAcademy.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Guid>
    {
        public UpdateCourseCommandHandler()
        {
            
        }
        public Task<Guid> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
