using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Contracts.Services;

namespace VirtualAcademy.Application.Features.Courses.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAllCoursesByAcademyId(Guid academyId)
        {
            var coursesToDelete = await _unitOfWork.CourseRepository.GetAllByAcademyIdAsync(academyId);

            foreach (var course in coursesToDelete)
            {
                var students = (await _unitOfWork.StudentRepository.GetAllByCourseIdAsync(course.Id)).ToList();
                students.ForEach(x => x.CourseId = null);

                var subjectsToDeleteByCourseId = await _unitOfWork.SubjectRepository.GetAllSubjectsWithMarksByCourseIdAsync(course.Id);
                foreach (var subject in subjectsToDeleteByCourseId)
                {
                    _unitOfWork.SubjectMarkRepository.DeleteRange(subject.Marks);
                    //to do group service and deleting groups
                    subject.IsDeleted = true;
                }

                course.IsDeleted = true;
            }
        }
    }
}
