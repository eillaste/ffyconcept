//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using TolerableUpperIntakeLevel = BLL.App.DTO.TolerableUpperIntakeLevel;

namespace WebApp.ViewModels
{
    public class TolerableUpperIntakeLevelCreateEditViewModel
    {
        public TolerableUpperIntakeLevel TolerableUpperIntakeLevel { get; set; } = default!;

        public SelectList? NutrientSelectList { get; set; }
    }
}