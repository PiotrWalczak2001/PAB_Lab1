using VirtualAcademy.Application.Features.Courses.Models;

namespace VirtualAcademy.Application.Features.Academies.Models
{
    public class AcademyInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string Description { get; set; }
        public IEnumerable<CourseInfoModel> Courses { get; set; }
        public Guid? ImageId { get; set; }
    }
}
