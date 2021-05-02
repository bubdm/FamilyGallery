using AutoMapper;
using FamilyGallery.Application.Features;
using FamilyGallery.Application.Features.Albums.Commands.CreateAlbum;
using FamilyGallery.Application.Features.Albums.Commands.UpdateAlbum;
using FamilyGallery.Application.Features.Families.Commands;
using FamilyGallery.Application.Features.Families.Commands.UpdateFamily;
using FamilyGallery.Application.Features.FamilyMembers.Commands.CreateFamilyMember;
using FamilyGallery.Domain.Entities;

namespace FamilyGallery.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Family, FamilyVm>().ReverseMap();
            CreateMap<Family, CreateFamilyCommand>().ReverseMap();        
            CreateMap<Family, UpdateFamilyCommand>().ForMember(uac => uac.UpdaterId, a => a.MapFrom(src => src.CreatorId)).ReverseMap();

            CreateMap<FamilyMember, FamilyMemberVm>().ReverseMap();
            CreateMap<FamilyMember, CreateFamilyMemberCommand>().ReverseMap();

            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<User, CreateFamilyMemberCommand>().ReverseMap();

            CreateMap<Album, AlbumVm>().ReverseMap();
            CreateMap<Album, CreateAlbumCommand>().ReverseMap();
            CreateMap<Album, UpdateAlbumCommand>().ForMember(uac => uac.UpdaterId, a => a.MapFrom(src => src.CreatorId) ).ReverseMap();
        }
    }
}
