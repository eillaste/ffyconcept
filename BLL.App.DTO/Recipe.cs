using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Recipe: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        
        public virtual AppUser AppUser { get; set; }  = null!;
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageMaxLength")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Recipe), Name = nameof(Description))]
        public string Description { get; set; } = null!;
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(2048)]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Recipe), Name = nameof(Instructions))]
        public string Instructions { get; set; } = null!;

        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Recipe), Name = nameof(Servings))]
        public int Servings { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Recipe), Name = nameof(PrepTime))]
        public TimeSpan PrepTime { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Recipe), Name = nameof(RestaurantRecipe))]
        public bool RestaurantRecipe { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Recipe), Name = nameof(Image))]
        public string Image { get; set; } = null!;

        public virtual ICollection<RecipeTag>? RecipeTags {get; set; }
        public virtual ICollection<DishInMenu>? DishInMenus { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<PersonFavoriteRecipe>? PersonFavoriteRecipes { get; set; }
        
    }
}