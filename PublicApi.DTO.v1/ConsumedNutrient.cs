using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using Nutrient = PublicApi.DTO.v1.Nutrient;

namespace PublicApi.DTO.v1
{
    
    public class ConsumedNutrientAddPut: DomainEntityId
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        //  public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        public Guid AppUserId { get; set; }

        public String Nutrient { get; set; } = default!;
        public DateTime Date { get; set; }
        
        public double Quantity { get; set; }
    }
    public class ConsumedNutrient: DomainEntityId
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        //public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }

        public Guid NutrientId { get; set; }
        //public virtual Nutrient? Nutrient { get; set; }
        public virtual String Nutrient { get; set; } = default!;

        public DateTime Date { get; set; }
        
        public double Quantity { get; set; }

    }
}