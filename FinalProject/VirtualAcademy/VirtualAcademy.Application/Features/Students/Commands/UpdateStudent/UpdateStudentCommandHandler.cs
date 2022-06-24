using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await _unitOfWork.StudentRepository.GetByIdAsync(request.Id);

            if (studentToUpdate == null)
                throw new ArgumentNullException(nameof(studentToUpdate));

            studentToUpdate.AcademyId = request.AcademyId;
            studentToUpdate.FirstName = request.FirstName;
            studentToUpdate.SecondName = request.SecondName;
            studentToUpdate.Surname = request.Surname;
            studentToUpdate.CountryDocumentCode = request.CountryDocumentCode;
            studentToUpdate.BirthDate = request.BirthDate;
            studentToUpdate.Gender = request.Gender;
            studentToUpdate.Nationality = request.Nationality;
            studentToUpdate.Citizenship = request.Citizenship;
            studentToUpdate.Street = request.Street;
            studentToUpdate.ZipCode = request.ZipCode;
            studentToUpdate.City = request.City;
            studentToUpdate.PostOffice = request.PostOffice;
            studentToUpdate.PrivateEmail = request.PrivateEmail;
            studentToUpdate.PhoneNumber = request.PhoneNumber;
            studentToUpdate.BirthPlace = request.BirthPlace;
            studentToUpdate.SeriesAndNumberIdentityCard = request.SeriesAndNumberIdentityCard;
            studentToUpdate.IdentityCardIssuedBy = request.IdentityCardIssuedBy;
            studentToUpdate.MotherName = request.MotherName;
            studentToUpdate.MotherMaidenName = request.MotherMaidenName;
            studentToUpdate.FatherMaidenName = request.FatherMaidenName;
            studentToUpdate.FatherName = request.FatherName;
            studentToUpdate.IsStudying = request.IsStudying;
            studentToUpdate.TitleAfterGraduation = request.TitleAfterGraduation;
            studentToUpdate.YearOfStudy = request.YearOfStudy;
            studentToUpdate.RecruitmentDate = request.RecruitmentDate;
            studentToUpdate.CourseId = request.CourseId;
            studentToUpdate.CurrentSemesterId = request.CurrentSemesterId;
            studentToUpdate.ExpectedGraduationDate = request.ExpectedGraduationDate;
            studentToUpdate.IndividualCourse = request.IndividualCourse;
            studentToUpdate.StartStudiesDate = request.StartStudiesDate;

            _unitOfWork.StudentRepository.Update(studentToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return studentToUpdate.Id;
        }
    }
}
