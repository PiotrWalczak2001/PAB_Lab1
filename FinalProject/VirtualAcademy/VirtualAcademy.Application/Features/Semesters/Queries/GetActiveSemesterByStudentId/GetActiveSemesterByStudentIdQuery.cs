using MediatR;
using VirtualAcademy.Application.Features.Semesters.Models;

namespace VirtualAcademy.Application.Features.Semesters.Queries.GetActiveSemesterByStudentId
{
    public class GetActiveSemesterByStudentIdQuery : IRequest<SemesterInfoModel>
    {
        public Guid StudentId { get; set; }
    }
}
