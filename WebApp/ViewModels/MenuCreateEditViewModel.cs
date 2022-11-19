//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class MenuCreateEditViewModel
    {
        public Menu Menu { get; set; } = default!;
        public SelectList? RestaurantSelectList { get; set; }
    }
}