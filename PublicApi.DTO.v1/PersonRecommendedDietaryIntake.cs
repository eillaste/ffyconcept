using System;
using BLL.App.DTO.Identity;
using Domain.Base;
using RecommendedDietaryIntake = PublicApi.DTO.v1.RecommendedDietaryIntake;

namespace PublicApi.DTO.v1
{
    public class PersonRecommendedDietaryIntakeAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        
        public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }

        public Guid RecommendedDietaryIntakeId { get; set; }
        //public virtual RecommendedDietaryIntake? RecommendedDietaryIntake { get; set; }

        public Guid HealthSpecificationNutrientId { get; set; }
        ////public virtual PublicApi.DTO.v1.HealthSpecificationNutrient? HealthSpecificationNutrient { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        
    }
    
    public class PersonRecommendedDietaryIntake: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid NutrientId { get; set; }
        //public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        
        public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }

        public Guid RecommendedDietaryIntakeId { get; set; }
        public virtual RecommendedDietaryIntake? RecommendedDietaryIntake { get; set; }

        public Guid HealthSpecificationNutrientId { get; set; }
        //          public virtual PublicApi.DTO.v1.HealthSpecificationNutrient? HealthSpecificationNutrient { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        
    }
}