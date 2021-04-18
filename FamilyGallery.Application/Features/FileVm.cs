using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features
{
    public class FileVm
    {
        public Guid Id { get; set; }

        public string Path { get; set; }
     
        public string ContentType { get; set; }

        public string Extension { get; set; }

        public Int64 FileSize { get; set; }
    }
}
