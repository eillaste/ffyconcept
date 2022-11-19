//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class StockCreateEditViewModel
    {
        public Stock Stock { get; set; } = default!;

        public SelectList? FoodItemSelectList { get; set; }
    }
}