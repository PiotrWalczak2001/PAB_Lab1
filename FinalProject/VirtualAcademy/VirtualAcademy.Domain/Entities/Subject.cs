using VirtualAcademy.Domain.Common;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public SubjectPassFormEnum FormOfFinalSubjectPass { get; set; }
        public SubjectTypeEnum SubjectType { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Guid LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual IEnumerable<SubjectGroup> SubjectGroups { get; set; }
        public virtual IEnumerable<SubjectMark> Marks { get; set; }
    }
}
