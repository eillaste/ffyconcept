using System;
using Contracts.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class PersonFavoriteRecipe: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        public Guid RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }

  //      public Guid PersonId { get; set; }
  //      public Person? Person { get; set; }
    public Guid AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }  = null!;
    }
}