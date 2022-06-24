using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Semesters.Models
{
    public class SemesterInfoModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public SemesterTypeEnum SemesterType { get; set; }
        public Guid StudentId { get; set; }
        public SemesterStatusEnum Status { get; set; }
    }
}
