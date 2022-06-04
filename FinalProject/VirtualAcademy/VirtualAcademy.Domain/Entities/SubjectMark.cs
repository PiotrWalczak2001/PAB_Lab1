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
        public Guid SemesterId { get; set; }
        public Semester Semester { get; set; }
        public Guid LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public bool? IsFinalMark { get; set; }
        public DateTime DateOfGetMark { get; set; }
    }
}
