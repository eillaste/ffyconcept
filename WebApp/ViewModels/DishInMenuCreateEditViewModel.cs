//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class DishInMenuCreateEditViewModel
    {
        public DishInMenu DishInMenu { get; set; } = default!;
        public SelectList? RecipeSelectList { get; set; }
        public SelectList? MenuSelectList { get; set; }
    }
}