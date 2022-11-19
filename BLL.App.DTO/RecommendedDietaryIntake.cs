using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace BLL.App.DTO
{
    public class RecommendedDietaryIntake: DomainEntityId
    {


        public Guid NutrientId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.RecommendedDietaryIntake), Name = nameof(Nutrient))]
        public virtual Nutrient? Nutrient { get; set; }

        public Guid AgeGroupId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.RecommendedDietaryIntake), Name = nameof(AgeGroup))]
        public virtual AgeGroup? AgeGroup { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.RecommendedDietaryIntake), Name = nameof(Quantity))]
        public double Quantity { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.RecommendedDietaryIntake), Name = nameof(Gender))]
        public EGender Gender { get; set; }
        
        //public Guid PersonRecommendedDietaryIntakeId { get; set; }
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes  { get; set; }
    }
}