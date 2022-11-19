//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class DishInOrderCreateEditViewModel
    {
        public DishInOrder DishInOrder { get; set; } = default!;
        public SelectList? DishInMenuSelectList { get; set; }
        public SelectList? OrderSelectList { get; set; }
    }
}