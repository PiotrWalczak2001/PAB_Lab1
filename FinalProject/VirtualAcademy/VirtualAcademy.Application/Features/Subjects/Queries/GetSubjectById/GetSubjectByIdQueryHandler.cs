using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Subjects.Models;

namespace VirtualAcademy.Application.Features.Subjects.Queries.GetSubjectById
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSubjectByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SubjectInfoModel> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SubjectId.ToString()))
                throw new ArgumentNullException(nameof(request.SubjectId));

            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(request.SubjectId);

            if(subject == null)
                throw new ArgumentNullException(nameof(subject));

            return new SubjectInfoModel()
            {
                Id = subject.Id,
                Name = subject.Name,
                CourseId = subject.CourseId
            };
        }
    }
}
