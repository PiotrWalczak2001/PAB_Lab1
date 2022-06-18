using VirtualAcademy.Domain.Common;

namespace VirtualAcademy.Domain.Entities
{
    public class Department : BaseEntity
    {
        public Guid AcademyId { get; set; }
        public virtual Academy Academy { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IEnumerable<Lecturer> Lecturers { get; set; }
    }
}
