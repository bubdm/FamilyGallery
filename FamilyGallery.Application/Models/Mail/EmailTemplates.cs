using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Models.Mail
{
    public class EmailTemplates
    {
        public Template FamilyMemberInvite { get; set; }
        public Template NewAlbumNotification { get; set; }
        public Template NewAlbumItemNotification { get; set; }
    }
}
