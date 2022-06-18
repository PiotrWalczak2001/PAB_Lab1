using VirtualAcademy.Domain.Common;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public SemesterTypeEnum SemesterType { get; set; }
        public SubjectTypeEnum GroupType { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual IEnumerable<StudentGroup> StudentGroups { get; set; }
        public virtual IEnumerable<SubjectGroup> SubjectGroups { get; set; }
    }
}
