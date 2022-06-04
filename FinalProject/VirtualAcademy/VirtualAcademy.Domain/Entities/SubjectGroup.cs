namespace VirtualAcademy.Domain.Entities
{
    public class SubjectGroup
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
