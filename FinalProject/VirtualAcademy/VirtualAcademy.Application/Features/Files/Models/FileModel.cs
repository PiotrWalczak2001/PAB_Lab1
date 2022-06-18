namespace VirtualAcademy.Application.Features.Files.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public Guid AcademyId { get; set; }
        public Guid FileContentId { get; set; }
        public FileContentModel Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
