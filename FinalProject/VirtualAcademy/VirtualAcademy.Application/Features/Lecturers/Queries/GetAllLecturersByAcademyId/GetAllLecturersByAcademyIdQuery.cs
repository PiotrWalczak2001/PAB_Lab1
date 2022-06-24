using MediatR;
using VirtualAcademy.Application.Features.Lecturers.Models;

namespace VirtualAcademy.Application.Features.Lecturers.Queries.GetAllLecturersByAcademyId
{
    public class GetAllLecturersByAcademyIdQuery : IRequest<IEnumerable<LecturerListModel>>
    {
        public Guid AcademyId { get; set; }
    }
}
