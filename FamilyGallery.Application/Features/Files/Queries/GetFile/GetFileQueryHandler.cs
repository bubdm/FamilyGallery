using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Queries.GetFile
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, GetFileQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IFileRepository fileRepository;
        private readonly IAlbumRepository albumRepository;
        private readonly IAlbumMemberRepository albumMemberRepository;

        public GetFileQueryHandler(IMapper mapper, IFileRepository fileRepository, 
            IAlbumRepository albumRepository, IAlbumMemberRepository albumMemberRepository)
        {
            this.mapper = mapper;
            this.fileRepository = fileRepository;
            this.albumRepository = albumRepository;
            this.albumMemberRepository = albumMemberRepository;
        }

        public async Task<GetFileQueryResponse> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var response = new GetFileQueryResponse();
            var validator = new GetFileQueryValidator(fileRepository, albumRepository, albumMemberRepository);
            var validationResult = await validator.ValidateAsync(request, default);
            response.IsSuccessful = validationResult.IsValid;
            if (!validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }
            var file = await fileRepository.GetByIdAsync(request.FileId);
            response.Data = mapper.Map<FileVm>(file);
            response.IsSuccessful = true;
            return response;
        }
    }
}
