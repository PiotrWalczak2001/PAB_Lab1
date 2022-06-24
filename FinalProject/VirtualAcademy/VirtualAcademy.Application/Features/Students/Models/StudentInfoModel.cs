using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Students.Models
{
    public class StudentInfoModel
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string AcademyEmail { get; set; }
        public int Code { get; set; }
        public bool IsStudying { get; set; }
        public YearOfStudyEnum YearOfStudy { get; set; }
        public Guid CurrentSemesterId { get; set; }
        public bool IndividualCourse { get; set; }
        public Guid CourseId { get; set; }
    }
}
