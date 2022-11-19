//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nutrient = BLL.App.DTO.Nutrient;

namespace WebApp.ViewModels
{
    public class NutrientCreateEditViewModel
    {
        public Nutrient Nutrient { get; set; } = default!;

        public SelectList? StandardUnitSelectList { get; set; }
    }
}