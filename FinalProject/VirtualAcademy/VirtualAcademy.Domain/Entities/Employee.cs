using VirtualAcademy.Domain.Common;

namespace VirtualAcademy.Domain.Entities
{
    public class Employee : BasePerson
    {
        public bool StillWorking { get; set; }
        public bool IsLecturer { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public DateTime? EndOfWorkDate { get; set; }
    }
}
