using VirtualAcademy.Domain.Common;

namespace VirtualAcademy.Domain.Entities
{
    public class Course : BaseEntity
    {
        public Guid AcademyId { get; set; }
        public virtual Academy Academy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
        public virtual IEnumerable<Group> Groups { get; set; }
    }
}
