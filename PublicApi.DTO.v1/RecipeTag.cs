using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using Tag = PublicApi.DTO.v1.Tag;

namespace PublicApi.DTO.v1
{
    public class RecipeTagAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        public Guid RecipeId { get; set; }
        public virtual PublicApi.DTO.v1.Recipe? Recipe { get; set; }

        public Guid TagId { get; set; }
        public virtual Tag? Tag { get; set; }
    }
    
    public class RecipeTag: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; } 
        public virtual AppUser AppUser { get; set; } = null!;
        public Guid RecipeId { get; set; }
        public virtual PublicApi.DTO.v1.Recipe? Recipe { get; set; }

        public Guid TagId { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}