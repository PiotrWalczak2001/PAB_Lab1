using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Academies.Models;
using VirtualAcademy.Application.Features.Courses.Models;
using VirtualAcademy.Application.Features.Subjects.Models;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Academies.Queries.GetAcademyById
{
    public class GetAcademyByIdQueryHandler : IRequestHandler<GetAcademyByIdQuery, AcademyInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAcademyByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AcademyInfoModel> Handle(GetAcademyByIdQuery request, CancellationToken cancellationToken)
        {
            var wantedAcademy = await _unitOfWork.AcademyRepository.GetByIdWithCoursesAsync(request.AcademyId);

            if (wantedAcademy == null)
                throw new ArgumentNullException(nameof(wantedAcademy));

            AcademyInfoModel academyToReturn = new()
            {
                Id = wantedAcademy.Id,
                Description = wantedAcademy.Description,
                ShortDecription = wantedAcademy.ShortDecription,
                Name = wantedAcademy.Name,
                ImageId = wantedAcademy.ImageId,
            };

            List<CourseInfoModel> academyCourses = new();

            foreach (var course in wantedAcademy.Courses)
            {
                var academyCourse = new CourseInfoModel()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    AcademyId = course.AcademyId
                };

                List<SubjectInfoModel> courseSubjects = course.Subjects
                                                              .Where(x => x.SubjectType == SubjectTypeEnum.Lecture)
                                                              .Select(subject => new SubjectInfoModel()
                                                              {
                                                                  Id = subject.Id,
                                                                  Name = subject.Name,
                                                                  SubjectType = subject.SubjectType,
                                                                  CourseId = subject.CourseId,
                                                                  LecturerId = subject.LecturerId
                                                              })
                                                              .ToList();

                academyCourse.Subjects = courseSubjects;
                academyCourses.Add(academyCourse);
            }
            academyToReturn.Courses = academyCourses;

            return academyToReturn;
        }
    }
}
