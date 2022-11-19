//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PersonSupplementCreateEditViewModel
    {
        public PersonSupplement PersonSupplement { get; set; } = default!;

        public SelectList? SupplementSelectList { get; set; }
    }
}