using System;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class NutrientInFoodItemAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public Guid FoodItemId { get; set; }
        //public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        public double Quantity { get; set; }
    }
    
    public class NutrientInFoodItem: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public Guid FoodItemId { get; set; }
        //public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        public double Quantity { get; set; }
    }
}