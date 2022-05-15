using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class SubjectMark
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public SubjectPassFormEnum FormOfPass { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public bool? IsFinalMark { get; set; }
        public DateTime DateOfGetMark { get; set; }
    }
}
