using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Queries.GetFile
{
    public class GetFileQueryValidator : AbstractValidator<GetFileQuery>
    {
        private readonly IFileRepository fileRepository;
        private readonly IAlbumRepository albumRepository;
        private readonly IAlbumMemberRepository albumMemberRepository;

        public GetFileQueryValidator(IFileRepository fileRepository, IAlbumRepository albumRepository,
            IAlbumMemberRepository albumMemberRepository)
        {
            this.fileRepository = fileRepository;
            this.albumRepository = albumRepository;
            this.albumMemberRepository = albumMemberRepository;

            RuleFor(gfq => gfq).MustAsync(IsAlbumFile).WithMessage("That file does not belong to that album");
            RuleFor(gfq => gfq).MustAsync(CanAccessFile).WithMessage("Only the owner, family members or album members can access file");
        }

        private async Task<bool> IsAlbumFile(GetFileQuery getFileQuery, CancellationToken arg2)
        {
            var album = await albumRepository.GetByIdAsync(getFileQuery.AlbumId);
            var file = await fileRepository.GetByIdAsync(getFileQuery.FileId);
            return file.AlbumId == album.Id;
        }

        private async Task<bool> CanAccessFile(GetFileQuery getFileQuery, CancellationToken arg2)
        {
            var album = await albumRepository.GetByIdAsync(getFileQuery.AlbumId);
            var file = await fileRepository.GetByIdAsync(getFileQuery.FileId);

            if (album.CreatorId == getFileQuery.UserId) return true;
            if (album.ShareWith == Domain.Entities.ShareWith.Nobody) return false;
            if (album.ShareWith == Domain.Entities.ShareWith.AlbumMembers && await albumMemberRepository.IsAlbumMember(getFileQuery.AlbumId, getFileQuery.UserId)) return true;          
            return false;
        }
    }
}
