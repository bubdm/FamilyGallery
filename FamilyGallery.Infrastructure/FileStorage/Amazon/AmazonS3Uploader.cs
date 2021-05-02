using FamilyGallery.Application.Contracts.Infrastructure;
using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace FamilyGallery.Infrastructure.FileStorage.Amazon
{
    public class AmazonS3Uploader : IFileUploadService
    {
        public Task<FileUploadResult> Upload(dynamic file)
        {
            throw new NotImplementedException();
        }
    }
}
