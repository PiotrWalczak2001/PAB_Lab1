using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Lecturers.Models;

namespace VirtualAcademy.Application.Features.Lecturers.Queries.GetLecturerById
{
    public class GetLecturerByIdQueryHandler : IRequestHandler<GetLecturerByIdQuery, LecturerInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetLecturerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LecturerInfoModel> Handle(GetLecturerByIdQuery request, CancellationToken cancellationToken)
        {
            var lecturer = await _unitOfWork.LecturerRepository.GetByIdAsync(request.Id);
            if (lecturer == null)
                throw new ArgumentNullException(nameof(lecturer));

            return new LecturerInfoModel()
            {
                Id = lecturer.Id,
                FirstName = lecturer.FirstName,
                SecondName = lecturer.SecondName,
                Surname = lecturer.Surname,
                IsLecturer = lecturer.IsLecturer,
                AcademyId = lecturer.AcademyId,
                DepartmentId = lecturer.DepartmentId,
                EmployeeCode = lecturer.EmployeeCode
            };
        }
    }
}
