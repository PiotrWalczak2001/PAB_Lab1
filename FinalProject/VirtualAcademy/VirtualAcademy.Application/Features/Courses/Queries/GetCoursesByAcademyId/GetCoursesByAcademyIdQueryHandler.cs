using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Courses.Models;

namespace VirtualAcademy.Application.Features.Courses.Queries.GetCoursesByAcademyId
{
    public class GetCoursesByAcademyIdQueryHandler : IRequestHandler<GetCoursesByAcademyIdQuery, IEnumerable<CourseListModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCoursesByAcademyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CourseListModel>> Handle(GetCoursesByAcademyIdQuery request, CancellationToken cancellationToken)
        {
            List<CourseListModel> coursesToReturn = new();
            var coursesByAcademyId = await _unitOfWork.CourseRepository.GetAllByAcademyIdAsync(request.AcademyId);

            if (!coursesByAcademyId.Any())
                return coursesToReturn;

            foreach (var course in coursesByAcademyId)
            {
                coursesToReturn.Add(new CourseListModel()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    AcademyId = course.AcademyId,
                });
            }

            return coursesToReturn;
        }
    }
}
