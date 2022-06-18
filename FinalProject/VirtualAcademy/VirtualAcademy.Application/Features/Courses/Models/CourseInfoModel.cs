using VirtualAcademy.Application.Features.Subjects.Models;

namespace VirtualAcademy.Application.Features.Courses.Models
{
    public class CourseInfoModel
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<SubjectInfoModel> Subjects { get; set; }
    }
}
