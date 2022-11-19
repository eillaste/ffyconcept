//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class NutrientInSupplementCreateEditViewModel
    {
        public NutrientInSupplement NutrientInSupplement { get; set; } = default!;
        
        public SelectList? NutrientSelectList { get; set; }
        public SelectList? SupplementSelectList { get; set; }
    }
}