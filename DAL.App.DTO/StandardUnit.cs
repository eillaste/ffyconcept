using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class StandardUnit: DomainEntityId
    {

        [MaxLength(32)]
        public string? Title { get; set; }

        [MaxLength(4)]
        public string? Symbol { get; set; }

        public virtual ICollection<FoodItem>? FoodItems { get; set; }
        public virtual ICollection<Supplement>? Supplements { get; set; }
        public virtual ICollection<Nutrient>? Nutrients { get; set; }
    }
}