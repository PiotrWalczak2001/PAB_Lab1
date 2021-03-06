using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentNullException(nameof(request.Name));

            if (string.IsNullOrEmpty(request.AcademyId.ToString()))
                throw new ArgumentNullException(nameof(request.AcademyId));

            Course newCourse = new()
            {
                Id = new Guid(),
                AcademyId = request.AcademyId,
                Name = request.Name,
                Description = request.Description
            };

            await _unitOfWork.CourseRepository.AddAsync(newCourse);
            await _unitOfWork.SaveChangesAsync();
            return newCourse.Id;
        }
    }
}
