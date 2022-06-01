using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Semester
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastDate { get; set; }
        public SemesterTypeEnum SemesterType { get; set; }
        public Guid StudentId { get; set; }
        public double? Average { get; set; }
        public Student Student { get; set; }
        public IEnumerable<SubjectMark> InitialMarks { get; set; }
        public SemesterStatusEnum Status { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
