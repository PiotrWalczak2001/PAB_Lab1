using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Courses.Commands.DeleteCourse
{
    internal class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id.ToString()))
                throw new ArgumentNullException(nameof(request.Id));

            var courseToDelete = await _unitOfWork.CourseRepository.GetByIdAsync(request.Id);

            if (courseToDelete == null)
                throw new ArgumentNullException(nameof(courseToDelete));

            var students = (await _unitOfWork.StudentRepository.GetAllByCourseIdAsync(courseToDelete.Id)).ToList();
            students.ForEach(x => x.CourseId = null);

            _unitOfWork.StudentRepository.UpdateRange(students);

            var subjectsToDeleteByCourseId = await _unitOfWork.SubjectRepository.GetAllSubjectsWithMarksByCourseIdAsync(courseToDelete.Id);
            foreach (var subject in subjectsToDeleteByCourseId)
            {
                _unitOfWork.SubjectMarkRepository.DeleteRange(subject.Marks);
                //to do group service and deleting groups
                subject.IsDeleted = true;
            }
            _unitOfWork.SubjectRepository.UpdateRange(subjectsToDeleteByCourseId);

            courseToDelete.IsDeleted = true;
            
            _unitOfWork.CourseRepository.Update(courseToDelete);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
