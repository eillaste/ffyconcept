//using Domain.App;

using DAL.App.DTO;
using Domain.App.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppUser = BLL.App.DTO.Identity.AppUser;
using ConsumedFoodItem = BLL.App.DTO.ConsumedFoodItem;

namespace WebApp.ViewModels
{
    public class AppUserCreateEditViewModel
    {
        public AppUser AppUser { get; set; } = default!;

        public SelectList? GenderSelectList { get; set; }
    }
}