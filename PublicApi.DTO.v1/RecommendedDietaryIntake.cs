using System;
using System.Collections.Generic;
using Domain.App;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class RecommendedDietaryIntakeAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public Guid AgeGroupId { get; set; }
        //public virtual AgeGroup? AgeGroup { get; set; }

        public double Quantity { get; set; }

        public EGender Gender { get; set; }
        
        //public Guid PersonRecommendedDietaryIntakeId { get; set; }
        //public virtual ICollection<PublicApi.DTO.v1.PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes  { get; set; }
    }
    
    public class RecommendedDietaryIntake: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public Guid AgeGroupId { get; set; }
        //public virtual BLL.App.DTO.AgeGroup? AgeGroup { get; set; }

        public double Quantity { get; set; }

        public EGender Gender { get; set; }
        
        //public Guid PersonRecommendedDietaryIntakeId { get; set; }
        //public virtual ICollection<PublicApi.DTO.v1.PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes  { get; set; }
    }
}