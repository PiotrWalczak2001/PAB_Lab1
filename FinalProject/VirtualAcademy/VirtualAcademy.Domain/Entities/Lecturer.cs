namespace VirtualAcademy.Domain.Entities
{
    public class Lecturer : Employee
    {
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual IEnumerable<SubjectMark> Marks { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
        public virtual IEnumerable<StudentNote> StudentNotes { get; set; }
    }
}
