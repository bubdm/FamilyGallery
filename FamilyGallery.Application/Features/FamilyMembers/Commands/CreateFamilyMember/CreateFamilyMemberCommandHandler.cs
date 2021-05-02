using AutoMapper;
using FamilyGallery.Application.Contracts.Infrastructure;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Models.Mail;
using FamilyGallery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.FamilyMembers.Commands.CreateFamilyMember
{
    public class CreateFamilyMemberCommandHandler : IRequestHandler<CreateFamilyMemberCommand, Guid>
    {
        private readonly IFamilyMemberRepository familyMemberRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IInviteService inviteService;

        public CreateFamilyMemberCommandHandler(IFamilyMemberRepository familyMemberRepository, IUserRepository userRepository, IMapper mapper, IInviteService inviteService)
        {
            this.familyMemberRepository = familyMemberRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.inviteService = inviteService;
        }

        public async Task<Guid> Handle(CreateFamilyMemberCommand request, CancellationToken cancellationToken)
        {
            var familyMember = mapper.Map<FamilyMember>(request);
            var user = await userRepository.FindByEmail(request.Email);
            if (user == null)
            {
                user = mapper.Map<User>(request);
                user = await userRepository.AddAsync(user);
            }
            familyMember.UserId = user.Id;
            var result = await familyMemberRepository.AddAsync(familyMember);
            if (!await familyMemberRepository.IsFamilyMember(request.FamilyId, user.Id))
            {
                await inviteService.InviteFamilyMember(request);
            }
            return result.Id;
        }
    }
}
