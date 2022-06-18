using MediatR;
using VirtualAcademy.Application.Features.Academies.Models;

namespace VirtualAcademy.Application.Features.Academies.Queries.GetAllAcademyList
{
    public class GetAllAcademyListQuery : IRequest<IEnumerable<AcademyListModel>>
    {
    }
}
