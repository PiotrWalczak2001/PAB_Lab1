namespace VirtualAcademy.Application.Features.Employees.Models
{
    public class EmployeeInfoModel
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsLecturer { get; set; }
        public string AcademyEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
