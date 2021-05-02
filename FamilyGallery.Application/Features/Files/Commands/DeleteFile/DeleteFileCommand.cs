using MediatR;
using System;

namespace FamilyGallery.Application.Features.Files.Commands.DeleteFile
{
    public class DeleteFileCommand : IRequest<DeleteFileCommandResponse>
    {
        public Guid FileId { get; set; }

        public string Path { get; set; }

        public string ContentType { get; set; }

        public string Extension { get; set; }

        public Int64 FileSize { get; set; }

        public Guid CreatorId { get; set; }

        public Guid AlbumId { get; set; }

    }
}
