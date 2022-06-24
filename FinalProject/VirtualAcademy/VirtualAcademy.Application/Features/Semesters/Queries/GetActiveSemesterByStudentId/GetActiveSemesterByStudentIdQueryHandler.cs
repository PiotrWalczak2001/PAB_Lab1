using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Semesters.Models;

namespace VirtualAcademy.Application.Features.Semesters.Queries.GetActiveSemesterByStudentId
{
    public class GetActiveSemesterByStudentIdQueryHandler : IRequestHandler<GetActiveSemesterByStudentIdQuery, SemesterInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetActiveSemesterByStudentIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SemesterInfoModel> Handle(GetActiveSemesterByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var semester = await _unitOfWork.SemesterRepository.GetActiveSemesterByStudentIdAsync(request.StudentId);
            if (semester == null)
                throw new ArgumentNullException(nameof(semester));

            return new SemesterInfoModel()
            {
                Id = semester.Id,
                StudentId = semester.Id,
                Code = semester.Code,
                SemesterType = semester.SemesterType,
                Status = semester.Status,
                StartDate = semester.StartDate
            };
        }
    }
}
