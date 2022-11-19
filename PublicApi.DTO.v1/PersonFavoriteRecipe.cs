using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using Recipe = PublicApi.DTO.v1.Recipe;

namespace PublicApi.DTO.v1
{
    public class PersonFavoriteRecipeAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        public Guid RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }

        //      public Guid PersonId { get; set; }
        //      public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;
    }
    
    public class PersonFavoriteRecipe: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        public Guid RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }

  //      public Guid PersonId { get; set; }
  //      public Person? Person { get; set; }
    public Guid AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; } = null!;
    }
}