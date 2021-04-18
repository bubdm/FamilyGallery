using System;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        { }
    }

}
