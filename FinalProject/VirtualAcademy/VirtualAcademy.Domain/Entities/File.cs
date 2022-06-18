using VirtualAcademy.Domain.Common;

namespace VirtualAcademy.Domain.Entities
{
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public Guid AcademyId { get; set; }
        public virtual Academy Academy { get; set; }
        public Guid FileContentId { get; set; }
        public virtual FileContent Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
