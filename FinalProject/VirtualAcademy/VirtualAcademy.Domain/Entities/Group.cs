using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsDeleted { get; set; }
        public SemesterTypeEnum SemesterType { get; set; }
        public SubjectTypeEnum GroupType { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Lecturer> Lecturers { get; set; }
    }
}
