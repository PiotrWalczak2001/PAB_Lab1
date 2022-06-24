namespace VirtualAcademy.Application.Features.Lecturers.Models
{
    public class LecturerListModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid AcademyId { get; set; }
    }
}
