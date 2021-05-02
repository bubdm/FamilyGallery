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

namespace FamilyGallery.Application.Features.Files.Commands.CreateFile
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, CreateFileCommandResponse>
    {
        private readonly IFileRepository fileRepository;
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;

        public CreateFileCommandHandler(IFileRepository fileRepository, IMapper mapper, IAlbumRepository albumRepository)
        {
            this.fileRepository = fileRepository;
            this.mapper = mapper;
            this.albumRepository = albumRepository;
        }

        public async Task<CreateFileCommandResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateFileCommandResponse();
            var validator = new CreateFileCommandValidator(albumRepository);
            var validationResult = await validator.ValidateAsync(request, default);
            response.IsSuccessful = validationResult.IsValid;
            if (validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }
            var file = mapper.Map<File>(request);
            file = await fileRepository.AddAsync(file);
            response.Data = mapper.Map<FileVm>(file);
            response.IsSuccessful = true;
            return response;
        }
    }
}
