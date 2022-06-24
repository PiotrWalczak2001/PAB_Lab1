using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Lecturers.Models;

namespace VirtualAcademy.Application.Features.Lecturers.Queries.GetAllLecturersByAcademyId
{
    public class GetAllLecturersByAcademyIdQueryHandler : IRequestHandler<GetAllLecturersByAcademyIdQuery, IEnumerable<LecturerListModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllLecturersByAcademyIdQueryHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LecturerListModel>> Handle(GetAllLecturersByAcademyIdQuery request, CancellationToken cancellationToken)
        {
            List<LecturerListModel> lecturerListModels = new();
            var lecturers = await _unitOfWork.LecturerRepository.GetAllByAcademyIdAsync(request.AcademyId);
            foreach (var lecturer in lecturers)
            {
                lecturerListModels.Add(new LecturerListModel()
                {
                    Id = lecturer.Id,
                    FirstName = lecturer.FirstName,
                    Surname = lecturer.Surname,
                    AcademyId = lecturer.AcademyId,
                    DepartmentId = lecturer.DepartmentId
                });
            }
            return lecturerListModels;
        }
    }
}
