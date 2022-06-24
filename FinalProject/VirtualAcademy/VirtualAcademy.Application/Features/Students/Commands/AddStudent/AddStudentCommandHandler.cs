using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Features.AcademyMails.Queries.CreateAcademyMail;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public AddStudentCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Guid> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            Student newStudent = new()
            {
                Id = Guid.NewGuid(),
                AcademyId = request.AcademyId,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                Surname = request.Surname,
                CountryDocumentCode = request.CountryDocumentCode,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                Nationality = request.Nationality,
                Citizenship = request.Citizenship,
                Street = request.Street,
                ZipCode = request.ZipCode,
                City = request.City,
                PostOffice = request.PostOffice,
                PrivateEmail = request.PrivateEmail,
                PhoneNumber = request.PhoneNumber,
                BirthPlace = request.BirthPlace,
                SeriesAndNumberIdentityCard = request.SeriesAndNumberIdentityCard,
                IdentityCardIssuedBy = request.IdentityCardIssuedBy,
                MotherName = request.MotherName,
                MotherMaidenName = request.MotherMaidenName,
                FatherMaidenName = request.FatherMaidenName,
                FatherName = request.FatherName,
                IsStudying = true,
                TitleAfterGraduation = request.TitleAfterGraduation,
                YearOfStudy = request.YearOfStudy,
                RecruitmentDate = DateTime.Today,
                CourseId = request.CourseId,
                CurrentSemesterId = request.CurrentSemesterId,
                ExpectedGraduationDate = request.ExpectedGraduationDate,
                IndividualCourse = request.IndividualCourse,
                StartStudiesDate = request.StartStudiesDate
            };
            newStudent.AcademyEmail = await _mediator.Send(new CreateAcademyMailQuery()
                { FirstName = request.FirstName, LastName = request.Surname });

            await _unitOfWork.StudentRepository.AddAsync(newStudent);
            await _unitOfWork.SaveChangesAsync();

            return newStudent.Id;
        }
    }
}
