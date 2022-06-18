namespace VirtualAcademy.Application.Features.Lecturers.Models
{
    public class LecturerInfoModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid EmployeeCode { get; set; }
        public Guid AcademyId { get; set; }
        public bool IsLecturer { get; set; }
    }
}
