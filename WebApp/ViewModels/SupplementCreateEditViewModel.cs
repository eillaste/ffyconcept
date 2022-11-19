//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SupplementCreateEditViewModel
    {
        public Supplement Supplement { get; set; } = default!;

        public SelectList? StandardUnitSelectList { get; set; }
    }
}