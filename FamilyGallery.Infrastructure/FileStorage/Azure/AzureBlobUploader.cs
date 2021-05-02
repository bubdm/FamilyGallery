using FamilyGallery.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Infrastructure.FileStorage.Azure
{
    public class AzureBlobUploader : IFileUploadService
    {
        public Task<FileUploadResult> Upload(dynamic file)
        {
            throw new NotImplementedException();
        }
    }
}
