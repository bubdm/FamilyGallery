using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features
{
    public class FamilyMemberVm
    {
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }

        public Guid UserId { get; set; }

        public FamilyVm Family { get; set; }

        public UserVm User { get; set; }
    }
}
