//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConsumedFoodItem = BLL.App.DTO.ConsumedFoodItem;

namespace WebApp.ViewModels
{
    public class ConsumedFoodItemCreateEditViewModel
    {
        public ConsumedFoodItem ConsumedFoodItem { get; set; } = default!;

        public SelectList? FoodItemSelectList { get; set; }
    }
}