using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllByAcademyIdAsync(Guid academyId);
        Task<IEnumerable<Student>> GetAllByCourseIdAsync(Guid CourseId);
    }
}
