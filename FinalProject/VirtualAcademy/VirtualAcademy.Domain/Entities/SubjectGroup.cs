namespace VirtualAcademy.Domain.Entities
{
    public class SubjectGroup
    {
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
