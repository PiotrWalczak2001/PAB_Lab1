using VirtualAcademy.Domain.Common;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Semester : BaseEntity
    {
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastDate { get; set; }
        public SemesterTypeEnum SemesterType { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public double? Average { get; set; }
        public virtual IEnumerable<SubjectMark> Marks { get; set; }
        public SemesterStatusEnum Status { get; set; }
        public bool IsClosed { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsDeleted { get; set; }
    }
}