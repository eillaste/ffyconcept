using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class AgeGroup: DomainEntityId
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.AgeGroup), Name = nameof(LowerBound))]
        public int LowerBound { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.AgeGroup), Name = nameof(UpperBound))]
        public int UpperBound { get; set; }

        public virtual  ICollection<RecommendedDietaryIntake>? RecommendedDietaryIntakes { get; set; }
    }
    
        
}