using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Exceptions;
using FamilyGallery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommand, UpdateFamilyCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IFamilyMemberRepository familyMemberRepository;

        public UpdateFamilyCommandHandler(IMapper mapper, IFamilyMemberRepository familyRepository)
        {
            this.mapper = mapper;
            this.familyMemberRepository = familyRepository;
        }
        public async Task<UpdateFamilyCommandResponse> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFamilyCommandValidator(familyMemberRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new UpdateFamilyCommandResponse{ IsSuccessful = false, Message = validationResult.ToString() };
            }
            var family = await familyMemberRepository.GetByIdAsync(request.Id);
            mapper.Map(request, family, typeof(UpdateFamilyCommand), typeof(Family));
            await familyMemberRepository.UpdateAsync(family);
            return new UpdateFamilyCommandResponse { IsSuccessful = true, Data = mapper.Map<FamilyVm>(family) };
        }
    }
}
