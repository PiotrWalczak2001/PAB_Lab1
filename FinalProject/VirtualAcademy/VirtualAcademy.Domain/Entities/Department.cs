namespace VirtualAcademy.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public Academy Academy { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Lecturer> Lecturers { get; set; }
    }
}
