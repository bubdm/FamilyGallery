using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommmandHandler : IRequestHandler<DeleteAlbumCommand, DeleteAlbumCommandResponse>
    {
        private readonly IAlbumRepository albumRepository;

        public DeleteAlbumCommmandHandler(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }
        public async Task<DeleteAlbumCommandResponse> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAlbumCommandValidator(albumRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new DeleteAlbumCommandResponse { IsSuccessful=false, Message = validationResult.ToString() };
            }
            var album = await albumRepository.GetByIdAsync(request.AlbumId);
            await albumRepository.DeleteAsync(album);
            return new DeleteAlbumCommandResponse { IsSuccessful = true  };
        }
    }
}
