using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbum
{
    public class GetAlbumQueryValidator : AbstractValidator<GetAlbumQuery>
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IAlbumMemberRepository albumMemberRepository;

        public GetAlbumQueryValidator(IAlbumRepository albumRepository, IAlbumMemberRepository albumMemberRepository)
        {
            this.albumRepository = albumRepository;
            this.albumMemberRepository = albumMemberRepository;
            RuleFor(a => a).MustAsync(CanAccessAlbum).WithMessage("Only authorized persons can access an album");
        }

        private async Task<bool> CanAccessAlbum(GetAlbumQuery getAlbumQuery, CancellationToken arg2)
        {
            var album = await albumRepository.GetByIdAsync(getAlbumQuery.AlbumId);
            if (album.CreatorId == getAlbumQuery.UserId) return true;
            if (album.ShareWith == Domain.Entities.ShareWith.Nobody) return false;
            if (album.ShareWith == Domain.Entities.ShareWith.AlbumMembers && await albumMemberRepository.IsAlbumMember(getAlbumQuery.AlbumId, getAlbumQuery.UserId)) return true;
            return false;
        }
    }
}
