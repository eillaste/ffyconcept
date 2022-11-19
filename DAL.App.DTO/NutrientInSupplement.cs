using System;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class NutrientInSupplement: DomainEntityId
    {

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
}