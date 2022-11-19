using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class PersonAllergenAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }

        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
        public Guid FoodItemId { get; set; }
        public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        [MaxLength(128)]
        public string Description { get; set; } = null!;
    }
    
    public class PersonAllergen: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }

        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;
        
        public Guid FoodItemId { get; set; }
        public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        [MaxLength(128)]
        public string Description { get; set; } = null!;
    }
}