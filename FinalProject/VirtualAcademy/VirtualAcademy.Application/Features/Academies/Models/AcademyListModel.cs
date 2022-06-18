namespace VirtualAcademy.Application.Features.Academies.Models
{
    public class AcademyListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public Guid? ImageId { get; set; }
    }
}
