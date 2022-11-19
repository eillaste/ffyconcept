using System;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class TolerableUpperIntakeLevelAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
    
    public class TolerableUpperIntakeLevel: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
}