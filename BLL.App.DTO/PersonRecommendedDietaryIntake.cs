using System;
using BLL.App.DTO.Identity;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class PersonRecommendedDietaryIntake: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }

        public Guid RecommendedDietaryIntakeId { get; set; }
        public virtual RecommendedDietaryIntake? RecommendedDietaryIntake { get; set; }

        public Guid HealthSpecificationNutrientId { get; set; }
        public virtual HealthSpecificationNutrient? HealthSpecificationNutrient { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        
    }
}