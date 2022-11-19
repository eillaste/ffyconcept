//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecommendedDietaryIntake = BLL.App.DTO.RecommendedDietaryIntake;

namespace WebApp.ViewModels
{
    public class RecommendedDietaryIntakeCreateEditViewModel
    {
        public RecommendedDietaryIntake RecommendedDietaryIntake { get; set; } = default!;
        
        public SelectList? NutrientSelectList { get; set; }
        public SelectList? AgeGroupSelectList { get; set; }
    }
}