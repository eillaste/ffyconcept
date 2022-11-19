using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
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