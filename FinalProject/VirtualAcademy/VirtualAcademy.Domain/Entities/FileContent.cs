using VirtualAcademy.Domain.Common;
using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Domain.Entities
{
    public class FileContent : BaseEntity
    {
        public Guid FileId { get; set; }
        public virtual File File { get; set; }
        public byte[] Content { get; set; }
    }
}
