//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodItem = BLL.App.DTO.FoodItem;

namespace WebApp.ViewModels
{
    public class FoodItemCreateEditViewModel
    {
        public FoodItem FoodItem { get; set; } = default!;
        
        public SelectList? StandardUnitSelectList { get; set; }
        public SelectList? CategorySelectList { get; set; }
    }
}