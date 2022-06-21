using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id.ToString()))
                throw new ArgumentNullException(nameof(request.Id));

            var courseToUpdate = await _unitOfWork.CourseRepository.GetByIdAsync(request.Id);

            if (courseToUpdate == null)
                throw new ArgumentNullException(nameof(courseToUpdate));

            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentNullException(nameof(request.Name));

            courseToUpdate.Name = request.Name;
            courseToUpdate.Description = request.Description;

            return courseToUpdate.Id;
        }
    }
}
