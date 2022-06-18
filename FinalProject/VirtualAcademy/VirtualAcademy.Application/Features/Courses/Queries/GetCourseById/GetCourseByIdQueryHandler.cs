using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Courses.Models;
using VirtualAcademy.Application.Features.Subjects.Models;

namespace VirtualAcademy.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CourseInfoModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var wantedCourse = await _unitOfWork.CourseRepository.GetWithSubjectsByIdAsync(request.CourseId);

            if (wantedCourse == null)
                throw new ArgumentNullException(nameof(wantedCourse));

            CourseInfoModel courseToReturn = new()
            {
                Id = wantedCourse.Id,
                Name = wantedCourse.Name,
                Description = wantedCourse.Description,
                AcademyId = wantedCourse.AcademyId,
            };

            List<SubjectInfoModel> courseSubjects = new();
            var subjects = await _unitOfWork.SubjectRepository.GetLectureTypeSubjectsByCourseIdAsync(request.CourseId);

            foreach (var subject in subjects)
            {
                courseSubjects.Add(new SubjectInfoModel()
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    SubjectType = subject.SubjectType,
                    CourseId = subject.CourseId,
                    LecturerId = subject.LecturerId
                });
            }
            courseToReturn.Subjects = courseSubjects;

            return courseToReturn;
        }
    }
}
