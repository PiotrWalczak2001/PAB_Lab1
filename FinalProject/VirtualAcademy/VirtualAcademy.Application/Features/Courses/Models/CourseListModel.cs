namespace VirtualAcademy.Application.Features.Courses.Models
{
    public class CourseListModel
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
