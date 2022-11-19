using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class StockAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;
        
        public Guid FoodItemId { get; set; }
        public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        public double Amount { get; set; }
    }
    
    public class Stock: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
        public Guid FoodItemId { get; set; }
        public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        public double Amount { get; set; }
    }
}