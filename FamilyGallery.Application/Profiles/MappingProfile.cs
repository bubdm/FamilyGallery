using AutoMapper;
using FamilyGallery.Application.Features;
using FamilyGallery.Application.Features.Families;
using FamilyGallery.Application.Features.Families.Commands;
using FamilyGallery.Application.Features.Families.Commands.UpdateFamily;
using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Family, FamilyVm>().ReverseMap();
            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<FamilyMember, FamilyMemberVm>().ReverseMap();
            CreateMap<Family, CreateFamilyCommand>().ReverseMap();        
            CreateMap<Family, UpdateFamilyCommand>().ReverseMap();
        }
    }
}
