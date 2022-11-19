using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class ConsumedFoodItem: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;

        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public DateTime Date { get; set; }
        
        public double Quantity { get; set; }
        public string? FoodItemName { get; set; }
    }
}