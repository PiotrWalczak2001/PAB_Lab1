using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Subjects.Models
{
    public class SubjectInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SubjectTypeEnum SubjectType { get; set; }
        public Guid CourseId { get; set; }
        public Guid LecturerId { get; set; }
    }
}
