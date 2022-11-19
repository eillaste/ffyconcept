//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class DietCreateEditViewModel
    {
        public Diet Diet { get; set; } = default!;   
    }
}