using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Models.Mail
{
    public class Email
    {
        public Email()
        {
            CC = new List<string>();
            BCC = new List<string>();
        }

        public string To { get; set; }
        
        public List<string> CC { get; set; }
        
        public List<string> BCC { get; set; }
        
        public string Subject { get; set; }
        
        public string Body { get; set; }
    }
}
