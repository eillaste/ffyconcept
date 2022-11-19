using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Ingredient = PublicApi.DTO.v1.Ingredient;
using NutrientInFoodItem = PublicApi.DTO.v1.NutrientInFoodItem;
using PersonAllergen = PublicApi.DTO.v1.PersonAllergen;
using StandardUnit = PublicApi.DTO.v1.StandardUnit;
using Stock = PublicApi.DTO.v1.Stock;

namespace PublicApi.DTO.v1
{
    public class FoodItemAddPut: DomainEntityId
    {
        
        //  public Guid Id { get; set; }
        
        [MaxLength(128)]
        public string? Title { get; set; }

        public Guid StandardUnitId { get; set; }
        //public virtual StandardUnit? StandardUnit { get; set; }

        public Guid CategoryId { get; set; }
        //public virtual PublicApi.DTO.v1.Category? Category { get; set; }

        /*
        public virtual ICollection<PersonAllergen>? PersonAllergens { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.DietaryRestriction>? DietaryRestrictions { get; set; }
        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<BLL.App.DTO.ConsumedFoodItem>? ConsumedFoodItems { get; set; }
        */


    }
    
    public class FoodItem: DomainEntityId
    {
        
        // public Guid Id { get; set; }
        
        [MaxLength(128)]
        public string? Title { get; set; }

        public Guid StandardUnitId { get; set; }
      //  public virtual StandardUnit? StandardUnit { get; set; }

        public Guid CategoryId { get; set; }
      //  public virtual PublicApi.DTO.v1.Category? Category { get; set; }

        /*
        public virtual ICollection<PersonAllergen>? PersonAllergens { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.DietaryRestriction>? DietaryRestrictions { get; set; }
        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<BLL.App.DTO.ConsumedFoodItem>? ConsumedFoodItems { get; set; }
        */


    }
}