namespace VirtualAcademy.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public Academy Academy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
