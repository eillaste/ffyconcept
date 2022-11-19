using System;
using System.ComponentModel.DataAnnotations;

//using Domain.App;

namespace PublicApi.DTO.v1
{
    public class FoodItemDTO
    {
        public Guid Id { get; set; }
        [MaxLength(128)]
        public string? Title { get; set; }

        public Guid StandardUnitId { get; set; }
        public virtual String StandardUnit { get; set; } = default!;

        public Guid CategoryId { get; set; }
        public virtual String Category { get; set; } = default!;

        public virtual int PersonAllergens { get; set; }
        public virtual int Ingredients { get; set; }
        public virtual int Stocks { get; set; }
        public virtual int DietaryRestrictions { get; set; }
        public virtual int NutrientInFoodItems { get; set; }
        public virtual int ConsumedFoodItems { get; set; }
    }
}