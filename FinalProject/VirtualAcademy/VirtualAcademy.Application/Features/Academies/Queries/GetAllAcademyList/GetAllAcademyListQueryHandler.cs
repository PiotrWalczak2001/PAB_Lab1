using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Academies.Models;

namespace VirtualAcademy.Application.Features.Academies.Queries.GetAllAcademyList
{
    public class GetAllAcademyListQueryHandler : IRequestHandler<GetAllAcademyListQuery, IEnumerable<AcademyListModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAcademyListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AcademyListModel>> Handle(GetAllAcademyListQuery request, CancellationToken cancellationToken)
        {
            var academies = await _unitOfWork.AcademyRepository.GetAllAsync();
            var academyListModels = new List<AcademyListModel>();
            foreach (var academy in academies)
            {
                academyListModels.Add(new AcademyListModel()
                {
                    Id = academy.Id,
                    Name = academy.Name,
                    ShortDecription = academy.ShortDecription,
                    ImageId = academy.ImageId,
                });
            }
            return academyListModels;
        }
    }
}
