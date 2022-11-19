//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PersonFavoriteRecipeCreateEditViewModel
    {
        public PersonFavoriteRecipe PersonFavoriteRecipe { get; set; } = default!;

        public SelectList? RecipeSelectList { get; set; }
    }
}