//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipe = BLL.App.DTO.Recipe;

namespace WebApp.ViewModels
{
    public class RecipeCreateEditViewModel
    {
        public Recipe Recipe { get; set; } = default!;
        
    }
}