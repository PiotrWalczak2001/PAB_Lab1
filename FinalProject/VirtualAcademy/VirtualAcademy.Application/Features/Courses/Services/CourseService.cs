using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Contracts.Services;

namespace VirtualAcademy.Application.Features.Courses.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubjectService _subjectService;
        public CourseService(IUnitOfWork unitOfWork, ISubjectService subjectService)
        {
            _unitOfWork = unitOfWork;
            _subjectService = subjectService;
        }

        public async Task DeleteAllCoursesByAcademyId(Guid academyId)
        {
            var coursesToDelete = (await _unitOfWork.CourseRepository.GetAllByAcademyIdAsync(academyId)).ToList();

            foreach (var course in coursesToDelete)
            {
                var students = (await _unitOfWork.StudentRepository.GetAllByCourseIdAsync(course.Id)).ToList();
                students.ForEach(x => x.CourseId = null);

                await _subjectService.DeleteAllSubjectsWithMarksByCourseId(course.Id);

                course.IsDeleted = true;
            }
            _unitOfWork.CourseRepository.UpdateRange(coursesToDelete);
        }
    }
}
