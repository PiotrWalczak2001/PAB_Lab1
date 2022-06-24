using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            // to do validation + permissions
            var isLecturer = request.IsLecturer;

            // academy mail creator

            if (isLecturer)
            {
                var newLecturer = new Lecturer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    SecondName = request.SecondName,
                    Surname = request.Surname,
                    IsLecturer = request.IsLecturer,
                    RecruitmentDate = request.RecruitmentDate ?? DateTime.Today,
                    IsDeleted = false,
                    StillWorking = true,
                    AcademyId = request.AcademyId,
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
                    DepartmentId = request.DepartmentId.GetValueOrDefault()
                };
                await _unitOfWork.LecturerRepository.AddAsync(newLecturer);
                await _unitOfWork.SaveChangesAsync();
                return newLecturer.Id;
            }
            
            Employee newEmployee = new()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                Surname = request.Surname,
                IsLecturer = request.IsLecturer,
                RecruitmentDate = request.RecruitmentDate ?? DateTime.Today,
                IsDeleted = false,
                StillWorking = true,
                AcademyId = request.AcademyId,
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
            };

            await _unitOfWork.EmployeeRepository.AddAsync(newEmployee);
            await _unitOfWork.SaveChangesAsync();
            return newEmployee.Id;
            
        }
    }
}
