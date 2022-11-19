using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.App
{
    public class RecommendedDietaryIntake: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public Guid AgeGroupId { get; set; }
        public virtual AgeGroup? AgeGroup { get; set; }

        public double Quantity { get; set; }

        public EGender Gender { get; set; }
        
        //public Guid PersonRecommendedDietaryIntakeId { get; set; }
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes  { get; set; }
    }
}