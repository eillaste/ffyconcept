using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class StandardUnit: DomainEntityId
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(32)]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.StandardUnit), Name = nameof(Title))]
        public string? Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(4)]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.StandardUnit), Name = nameof(Symbol))]
        public string? Symbol { get; set; }

        public virtual ICollection<FoodItem>? FoodItems { get; set; }
        public virtual ICollection<Supplement>? Supplements { get; set; }
        public virtual ICollection<Nutrient>? Nutrients { get; set; }
    }
}