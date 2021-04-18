using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features
{
    public class AlbumMemberVm
    {
        public int UserId { get; set; }

        public UserVm User { get; set; }
    }
}
