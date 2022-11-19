using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class TagAddPut: DomainEntityId
    {

        [MaxLength(64)]
        public string Name { get; set; } = null!;

        public virtual ICollection<PublicApi.DTO.v1.RecipeTag>? RecipeTags { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
    
    public class Tag: DomainEntityId
    {

        [MaxLength(64)]
        public string Name { get; set; } = null!;

        public virtual ICollection<PublicApi.DTO.v1.RecipeTag>? RecipeTags { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}