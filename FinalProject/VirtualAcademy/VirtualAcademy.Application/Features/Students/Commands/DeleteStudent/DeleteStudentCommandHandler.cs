using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await _unitOfWork.StudentRepository.GetByIdAsync(request.Id);
            if (studentToDelete == null)
                throw new ArgumentNullException(nameof(studentToDelete));

            studentToDelete.IsStudying = false;
            studentToDelete.IsDeleted = true;

            _unitOfWork.StudentRepository.Update(studentToDelete);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
