using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Infrastructure
{
    public interface IFileUploadService
    {
        Task<FileUploadResult> Upload(dynamic file);
    }
}
