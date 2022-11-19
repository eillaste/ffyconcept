using System;
using Domain.Base;

namespace Domain.App
{
    public class NutrientInFoodItem: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public double Quantity { get; set; }
    }
}