using System;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
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