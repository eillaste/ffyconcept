using System;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class ConsumedNutrient: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public DateTime Date { get; set; }
        
        public double Quantity { get; set; }
    }
}