using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features
{
    public class AlbumVm
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public bool IsPrivate { get; set; }

        public IReadOnlyCollection<AlbumMemberVm> Members { get; set; }
    }
}
