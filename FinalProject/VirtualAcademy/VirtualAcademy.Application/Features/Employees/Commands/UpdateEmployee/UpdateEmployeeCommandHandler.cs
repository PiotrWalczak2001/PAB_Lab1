using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // to do validation + permissions
            var isLecturer = request.IsLecturer;

            // academy mail creator

            if (isLecturer)
            {
                var lecturerToUpdate = await _unitOfWork.LecturerRepository.GetByIdAsync(request.Id);

                lecturerToUpdate.FirstName = request.FirstName;
                lecturerToUpdate.SecondName = request.SecondName;
                lecturerToUpdate.Surname = request.Surname;
                lecturerToUpdate.RecruitmentDate = request.RecruitmentDate ?? lecturerToUpdate.RecruitmentDate;
                lecturerToUpdate.StillWorking = request.StillWorking;
                lecturerToUpdate.AcademyId = request.AcademyId;
                lecturerToUpdate.CountryDocumentCode = request.CountryDocumentCode;
                lecturerToUpdate.BirthDate = request.BirthDate;
                lecturerToUpdate.Gender = request.Gender;
                lecturerToUpdate.Nationality = request.Nationality;
                lecturerToUpdate.Citizenship = request.Citizenship;
                lecturerToUpdate.Street = request.Street;
                lecturerToUpdate.ZipCode = request.ZipCode;
                lecturerToUpdate.City = request.City;
                lecturerToUpdate.PostOffice = request.PostOffice;
                lecturerToUpdate.PrivateEmail = request.PrivateEmail;
                lecturerToUpdate.PhoneNumber = request.PhoneNumber;
                lecturerToUpdate.DepartmentId = request.DepartmentId;

                _unitOfWork.LecturerRepository.Update(lecturerToUpdate);
                await _unitOfWork.SaveChangesAsync();
                return lecturerToUpdate.Id;
            }

            var employeeToUpdate = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);
                    
            employeeToUpdate.FirstName = request.FirstName;
            employeeToUpdate.SecondName = request.SecondName;
            employeeToUpdate.Surname = request.Surname;
            employeeToUpdate.RecruitmentDate = request.RecruitmentDate ?? employeeToUpdate.RecruitmentDate;
            employeeToUpdate.StillWorking = request.StillWorking;
            employeeToUpdate.AcademyId = request.AcademyId;
            employeeToUpdate.CountryDocumentCode = request.CountryDocumentCode;
            employeeToUpdate.BirthDate = request.BirthDate;
            employeeToUpdate.Gender = request.Gender;
            employeeToUpdate.Nationality = request.Nationality;
            employeeToUpdate.Citizenship = request.Citizenship;
            employeeToUpdate.Street = request.Street;
            employeeToUpdate.ZipCode = request.ZipCode;
            employeeToUpdate.City = request.City;
            employeeToUpdate.PostOffice = request.PostOffice;
            employeeToUpdate.PrivateEmail = request.PrivateEmail;
            employeeToUpdate.PhoneNumber = request.PhoneNumber;

            _unitOfWork.EmployeeRepository.Update(employeeToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return employeeToUpdate.Id;
            
        }
    }
}
