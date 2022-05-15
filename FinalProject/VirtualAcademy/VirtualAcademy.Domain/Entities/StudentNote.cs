namespace VirtualAcademy.Domain.Entities
{
    public class StudentNote
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public DateTime DateOfNote { get; set; }
    }
}
