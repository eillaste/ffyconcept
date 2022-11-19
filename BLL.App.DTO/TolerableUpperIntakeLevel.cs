using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class TolerableUpperIntakeLevel: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.TolerableUpperIntakeLevel), Name = nameof(Nutrient))]
        public virtual Nutrient? Nutrient { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.TolerableUpperIntakeLevel), Name = nameof(Quantity))]
        public double Quantity { get; set; }
    }
}