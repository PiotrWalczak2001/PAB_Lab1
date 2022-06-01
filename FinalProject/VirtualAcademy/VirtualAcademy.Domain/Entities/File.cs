namespace VirtualAcademy.Domain.Entities
{
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public Guid AcademyId { get; set; }
        public Academy Academy { get; set; }
        public Guid FileContentId { get; set; }
        public FileContent Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
