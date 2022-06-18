namespace VirtualAcademy.Application.Contracts.Services
{
    public interface ICourseService
    {
        Task DeleteAllCoursesByAcademyId(Guid academyId);
    }
}
