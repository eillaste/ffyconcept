using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Category: DomainEntityId
    {
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(64)]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Category), Name = nameof(Title))]
        public string Title { get; set; } = null!;

        public virtual ICollection<FoodItem>? FoodItems { get; set; }
    }
}