using VirtualAcademy.Application.Features.Files.Models;

namespace VirtualAcademy.Application.Features.Files.Models
{
    public class FileContentModel
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public FileModel File { get; set; }
        public byte[] Content { get; set; }
    }
}
