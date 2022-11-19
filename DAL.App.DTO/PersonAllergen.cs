using System;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
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