namespace VirtualAcademy.Application.Features.Employees.Models
{
    public class EmployeeListModel
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsLecturer { get; set; }
    }
}
