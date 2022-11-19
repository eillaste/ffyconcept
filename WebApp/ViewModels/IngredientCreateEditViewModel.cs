//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ingredient = BLL.App.DTO.Ingredient;

namespace WebApp.ViewModels
{
    public class IngredientCreateEditViewModel
    {
        public Ingredient Ingredient { get; set; } = default!;
        public SelectList? FoodItemSelectList { get; set; }
        public SelectList? RecipeSelectList { get; set; }
    }
}