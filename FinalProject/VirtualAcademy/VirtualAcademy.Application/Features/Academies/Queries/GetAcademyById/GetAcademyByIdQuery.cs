using MediatR;
using VirtualAcademy.Application.Features.Academies.Models;

namespace VirtualAcademy.Application.Features.Academies.Queries.GetAcademyById
{
    public class GetAcademyByIdQuery : IRequest<AcademyInfoModel>
    {
        public Guid AcademyId { get; set; }
    }
}
