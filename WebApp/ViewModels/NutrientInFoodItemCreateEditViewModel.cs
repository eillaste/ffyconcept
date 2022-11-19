//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutrientInFoodItem = BLL.App.DTO.NutrientInFoodItem;

namespace WebApp.ViewModels
{
    public class NutrientInFoodItemCreateEditViewModel
    {
        public NutrientInFoodItem NutrientInFoodItem { get; set; } = default!;
        
        public SelectList? NutrientSelectList { get; set; }
        public SelectList? FoodItemSelectList { get; set; }
    }
}