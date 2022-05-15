using VirtualAcademy.Domain.Common;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Entities
{
    public class Student : BasePerson
    {
        public int Code { get; set; }
        public string BirthPlace { get; set; }
        public string SeriesAndNumberIdentityCard { get; set; }
        public string IdentityCardIssuedBy { get; set; }
        public string MotherName { get; set; }
        public string MotherMaidenName { get; set; }
        public string FatherName { get; set; }
        public string FatherMaidenName { get; set; }
        public bool IsStudying { get; set; }
        public TitleEnum TitleAfterGraduation { get; set; }
        public YearOfStudyEnum YearOfStudy { get; set; }
        public Guid SemesterId { get; set; }
        public Semester Semester { get; set; }
        public DateTime StartStudiesDate { get; set; }
        public DateTime ExpectedGraduationDate { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public bool IndividualCourse { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<SubjectMark> Marks { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<StudentNote> StudentNotes { get; set; }
    }
}
