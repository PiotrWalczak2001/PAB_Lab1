using MediatR;
using VirtualAcademy.Application.Features.Lecturers.Models;

namespace VirtualAcademy.Application.Features.Lecturers.Queries.GetLecturerById
{
    public class GetLecturerByIdQuery : IRequest<LecturerInfoModel>
    {
        public Guid Id { get; set; }
    }
}
