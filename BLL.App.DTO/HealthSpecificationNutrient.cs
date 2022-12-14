using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class HealthSpecificationNutrient: DomainEntityId
    {

        public Guid HealthSpecificationId { get; set; }
        public virtual HealthSpecification? HealthSpecification { get; set; }

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }

        [MaxLength(128)]
        public string Comment { get; set; } = null!;
        
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes { get; set; }
    }
}