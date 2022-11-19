using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConsumedFoodItem = BLL.App.DTO.ConsumedFoodItem;
using ConsumedNutrient = BLL.App.DTO.ConsumedNutrient;

namespace WebApp.ViewModels
{
    public class ConsumedNutrientCreateEditViewModel
    {
        public ConsumedNutrient ConsumedNutrient { get; set; } = default!;

        public SelectList? NutrientSelectList { get; set; }
    }
}