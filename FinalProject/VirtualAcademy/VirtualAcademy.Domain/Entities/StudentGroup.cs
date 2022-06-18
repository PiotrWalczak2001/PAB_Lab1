namespace VirtualAcademy.Domain.Entities
{
    public class StudentGroup
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }        
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
