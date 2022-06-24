using MediatR;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<Guid>
    {
        public Guid AcademyId { get; set; }
        public bool IsLecturer { get; set; }
        public DateTime? RecruitmentDate { get; set; }
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
        public Guid? DepartmentId { get; set; }
    }
}
