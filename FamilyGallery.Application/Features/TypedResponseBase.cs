using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features
{
    public abstract class TypedResponseBase<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}
