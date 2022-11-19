//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class RestaurantCreateEditViewModel
    {
        public Restaurant Restaurant { get; set; } = default!;
    }
}