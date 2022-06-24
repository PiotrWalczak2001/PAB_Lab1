using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface ISemesterRepository : IBaseRepository<Semester>
    {
        Task<Semester> GetActiveSemesterByStudentIdAsync(Guid studentId);
    }
}
