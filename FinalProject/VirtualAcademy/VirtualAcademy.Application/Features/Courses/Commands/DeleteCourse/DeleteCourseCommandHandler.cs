using MediatR;

namespace VirtualAcademy.Application.Features.Courses.Commands.DeleteCourse
{
    internal class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        public DeleteCourseCommandHandler()
        {
            
        }
        public Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
