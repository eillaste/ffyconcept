using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Tag: DomainEntityId
    {

        [MaxLength(64)]
        public string Name { get; set; } = null!;

        public virtual ICollection<RecipeTag>? RecipeTags { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}