//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class HealthSpecificationNutrientCreateEditViewModel
    {
        public HealthSpecificationNutrient HealthSpecificationNutrient { get; set; } = default!;
        
        public SelectList? HealthSpecificationSelectList { get; set; }
        public SelectList? NutrientSelectList { get; set; }
    }
}