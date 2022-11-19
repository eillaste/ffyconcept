using System;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class DietaryRestriction: DomainEntityId
    {
//
        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public Guid DietId { get; set; }
        public virtual Diet? Diet { get; set; }

        [MaxLength(256)]
        public string Comment { get; set; } = null!;
    }
}