using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class FoodItem: DomainEntityId
    {

        [MaxLength(128)]
        public string? Title { get; set; }

        public Guid StandardUnitId { get; set; }
        public virtual StandardUnit? StandardUnit { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<PersonAllergen>? PersonAllergens { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<DietaryRestriction>? DietaryRestrictions { get; set; }
        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<ConsumedFoodItem>? ConsumedFoodItems { get; set; }


    }
}