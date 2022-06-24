using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Application.Contracts.Services;

namespace VirtualAcademy.Application.Features.Subjects.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteAllSubjectsWithMarksByCourseId(Guid courseId)
        {
            var subjectsToDeleteByCourseId = (await _unitOfWork.SubjectRepository.GetAllSubjectsWithMarksByCourseIdAsync(courseId)).ToList();
            foreach (var subject in subjectsToDeleteByCourseId)
            {
                _unitOfWork.SubjectMarkRepository.DeleteRange(subject.Marks);
                //to do group service and deleting groups
                subject.IsDeleted = true;
            }
            _unitOfWork.SubjectRepository.UpdateRange(subjectsToDeleteByCourseId);
        }
    }
}
