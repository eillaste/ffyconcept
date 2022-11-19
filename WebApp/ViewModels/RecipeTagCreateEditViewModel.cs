//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class RecipeTagCreateEditViewModel
    {
        public RecipeTag RecipeTag { get; set; } = default!;
        public SelectList? RecipeSelectList { get; set; }
        public SelectList? TagSelectList { get; set; }
    }
}