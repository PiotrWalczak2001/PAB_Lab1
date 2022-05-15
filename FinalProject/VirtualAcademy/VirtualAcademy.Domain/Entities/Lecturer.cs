namespace VirtualAcademy.Domain.Entities
{
    public class Lecturer : Employee
    {
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<SubjectMark> Marks { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<StudentNote> StudentNotes { get; set; }
    }
}
