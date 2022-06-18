﻿using MediatR;
using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Application.Features.Academies.Commands.UpdateAcademy
{
    public class UpdateAcademyCommandHandler : IRequestHandler<UpdateAcademyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAcademyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateAcademyCommand request, CancellationToken cancellationToken)
        {
            // to do validation and permissions
            var academyToUpdate = await _unitOfWork.AcademyRepository.GetByIdAsync(request.Id);

            if (academyToUpdate == null)
                throw new ArgumentNullException(nameof(academyToUpdate));

            academyToUpdate.Name = request.Name;
            academyToUpdate.Description = request.Description;
            academyToUpdate.ShortDecription = request.ShortDecription;
            academyToUpdate.ImageId = request.ImageId;

            _unitOfWork.AcademyRepository.Update(academyToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return request.Id;
        }
    }
}
