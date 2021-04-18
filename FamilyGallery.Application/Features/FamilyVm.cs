using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FamilyGallery.Application.Features
{
    public class FamilyVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid CreatorId { get; set; }

        public IReadOnlyList<UserVm> Members { get; set; }
    }
}