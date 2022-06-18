using VirtualAcademy.Domain.Common;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class SubjectMark : BaseEntity
    {
        public double Value { get; set; }
        public SubjectPassFormEnum FormOfPass { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        public Guid LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public bool? IsFinalMark { get; set; }
        public DateTime DateOfGetMark { get; set; }
    }
}
