using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Domain.Entities
{
    public class FileContent
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public File File { get; set; }
        public byte[] Content { get; set; }
    }
}
