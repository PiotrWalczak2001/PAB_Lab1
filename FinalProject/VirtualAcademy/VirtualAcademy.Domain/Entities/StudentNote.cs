using VirtualAcademy.Domain.Common;

namespace VirtualAcademy.Domain.Entities
{
    public class StudentNote : BaseEntity
    {
        public string Description { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public DateTime DateOfNote { get; set; }
    }
}
