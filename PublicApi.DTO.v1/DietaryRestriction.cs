using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using FoodItem = PublicApi.DTO.v1.FoodItem;

namespace PublicApi.DTO.v1
{
    
    public class DietaryRestrictionAddPut: DomainEntityId
    {

        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public Guid DietId { get; set; }
        public virtual PublicApi.DTO.v1.Diet? Diet { get; set; }

        [MaxLength(256)]
        public string Comment { get; set; } = null!;
    }
    public class DietaryRestriction: DomainEntityId
    {

        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public Guid DietId { get; set; }
        public virtual PublicApi.DTO.v1.Diet? Diet { get; set; }

        [MaxLength(256)]
        public string Comment { get; set; } = null!;
    }
}