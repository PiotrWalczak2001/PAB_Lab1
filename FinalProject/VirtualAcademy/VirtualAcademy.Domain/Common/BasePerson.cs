using VirtualAcademy.Domain.Entities;
using VirtualAcademy.Domain.Enums;

namespace VirtualAcademy.Domain.Common
{
    public abstract class BasePerson
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public Academy Academy { get; set; }
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
        public string AcademyEmail { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
