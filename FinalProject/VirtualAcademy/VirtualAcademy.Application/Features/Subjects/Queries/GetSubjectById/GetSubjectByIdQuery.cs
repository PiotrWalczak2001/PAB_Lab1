using MediatR;
using VirtualAcademy.Application.Features.Subjects.Models;

namespace VirtualAcademy.Application.Features.Subjects.Queries.GetSubjectById
{
    public class GetSubjectByIdQuery : IRequest<SubjectInfoModel>
    {
        public Guid SubjectId { get; set; }
    }
}
