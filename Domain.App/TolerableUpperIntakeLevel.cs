using System;
using Domain.Base;

namespace Domain.App
{
    public class TolerableUpperIntakeLevel: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
}