using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Exceptions;
using FamilyGallery.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.CreateFamily
{
    public class CreateFamilyCommandHandler : IRequestHandler<CreateFamilyCommand, CreateFamilyCommandResponse>
    {
        private readonly IFamilyRepository familyRepository;
        private readonly IMapper mapper;
        private readonly IFamilyMemberRepository familyMemberRepository;

        public CreateFamilyCommandHandler(IFamilyRepository familyRepository, IMapper mapper, IFamilyMemberRepository familyMemberRepository)
        {
            this.familyRepository = familyRepository;
            this.mapper = mapper;
            this.familyMemberRepository = familyMemberRepository;
        }
        public async Task<CreateFamilyCommandResponse> Handle(CreateFamilyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFamilyCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new CreateFamilyCommandResponse { IsSuccessful = false, Message = validationResult.ToString() };
            }
            var family = mapper.Map<Family>(request);
            family = await familyRepository.AddAsync(family);
            await familyMemberRepository.AddAsync(new FamilyMember { FamilyId = family.Id, CreatorId = family.CreatorId, UserId = request.CreatorId });
            return new CreateFamilyCommandResponse { Data = mapper.Map<FamilyVm>(family), IsSuccessful = true };
        }
    }
}
