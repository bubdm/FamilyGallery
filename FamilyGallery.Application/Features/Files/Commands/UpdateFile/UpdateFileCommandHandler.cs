using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Commands.UpdateFile
{
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, UpdateFileCommandResponse>
    {
        private readonly IFileRepository fileRepository;
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;

        public UpdateFileCommandHandler(IFileRepository fileRepository, IMapper mapper, IAlbumRepository albumRepository)
        {
            this.fileRepository = fileRepository;
            this.mapper = mapper;
            this.albumRepository = albumRepository;
        }

        public async Task<UpdateFileCommandResponse> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateFileCommandResponse();
            var validator = new UpdateFileCommandValidator(albumRepository, fileRepository);
            var validationResult = await validator.ValidateAsync(request, default);
            response.IsSuccessful = validationResult.IsValid;
            if (validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }
            var file = await fileRepository.GetByIdAsync(request.FileId);
            mapper.Map(request, file, typeof(UpdateFileCommand), typeof(File));
            await fileRepository.UpdateAsync(file);
            response.Data = mapper.Map<FileVm>(file);
            response.IsSuccessful = true;
            return response;
        }
    }
}
