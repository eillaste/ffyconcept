using System;
using Domain.Base;

namespace DAL.App.DTO
{
    public class TolerableUpperIntakeLevel: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
}