//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class DietaryRestrictionCreateEditViewModel
    {
        public DietaryRestriction DietaryRestriction { get; set; } = default!;

        public SelectList? FoodItemSelectList { get; set; }
        public SelectList? DietSelectList { get; set; }
    }
}