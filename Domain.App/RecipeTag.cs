using System;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class RecipeTag: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        public Guid RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }

        public Guid TagId { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}