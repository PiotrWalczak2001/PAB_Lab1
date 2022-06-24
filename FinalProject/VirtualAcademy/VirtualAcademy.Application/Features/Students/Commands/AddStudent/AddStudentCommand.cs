using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommand : IRequest<Guid>
    {
        public Guid AcademyId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string CountryDocumentCode { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public string Nationality { get; set; }
        public string Citizenship { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PostOffice { get; set; }
        public string PrivateEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public string SeriesAndNumberIdentityCard { get; set; }
        public string IdentityCardIssuedBy { get; set; }
        public string MotherName { get; set; }
        public string MotherMaidenName { get; set; }
        public string FatherName { get; set; }
        public string FatherMaidenName { get; set; }
        public TitleEnum TitleAfterGraduation { get; set; }
        public YearOfStudyEnum YearOfStudy { get; set; }
        public Guid CurrentSemesterId { get; set; }
        public DateTime StartStudiesDate { get; set; }
        public DateTime ExpectedGraduationDate { get; set; }
        public bool IndividualCourse { get; set; }
        public Guid? CourseId { get; set; }
    }
}
