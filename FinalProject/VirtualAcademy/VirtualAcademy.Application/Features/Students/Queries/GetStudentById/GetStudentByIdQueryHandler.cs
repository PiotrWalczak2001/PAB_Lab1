using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.Students.Models;

namespace VirtualAcademy.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery ,StudentInfoModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetStudentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentInfoModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(request.Id);
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            return new StudentInfoModel()
            {
                Id = student.Id,
                AcademyId = student.AcademyId,
                AcademyEmail = student.AcademyEmail,
                FirstName = student.FirstName,
                Surname = student.Surname,
                CourseId = student.CourseId.GetValueOrDefault(),
                Code = student.Code,
                CurrentSemesterId = student.CurrentSemesterId,
                IndividualCourse = student.IndividualCourse,
                IsStudying = student.IsStudying,
                YearOfStudy = student.YearOfStudy
            };
        }
    }
}
