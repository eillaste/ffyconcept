using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;

namespace BLL.App.DTO
{
    public class PersonAllergen: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }

        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        [MaxLength(128)]
        public string Description { get; set; } = null!;
    }
}