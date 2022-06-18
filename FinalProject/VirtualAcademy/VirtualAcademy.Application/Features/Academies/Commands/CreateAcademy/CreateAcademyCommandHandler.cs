using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Entities;

namespace VirtualAcademy.Application.Features.Academies.Commands.CreateAcademy
{
    public class CreateAcademyCommandHandler : IRequestHandler<CreateAcademyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAcademyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateAcademyCommand request, CancellationToken cancellationToken)
        {
            // to do validation + permissions
            Academy academy = new() 
            {
                Id = new Guid(),
                Name = request.Name,
                Description = request.Description,
                ShortDecription = request.ShortDecription,
                ImageId = request.ImageId,
                IsDeleted = false,
            };

            await _unitOfWork.AcademyRepository.AddAsync(academy);
            await _unitOfWork.SaveChangesAsync();

            return academy.Id;
        }
    }
}
