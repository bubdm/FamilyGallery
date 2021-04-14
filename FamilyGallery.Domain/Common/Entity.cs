using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Domain.Common
{
    public class Entity<T> where T : struct
    {
        public T Id { get; set; }
    }
}
