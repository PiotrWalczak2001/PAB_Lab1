using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public SubjectPassFormEnum FormOfFinalSubjectPass { get; set; }
        public SubjectTypeEnum SubjectType { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
