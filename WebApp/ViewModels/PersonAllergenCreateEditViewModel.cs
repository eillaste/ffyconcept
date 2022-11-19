//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PersonAllergenCreateEditViewModel
    {
        public PersonAllergen PersonAllergen { get; set; } = default!;

        public SelectList? AllergenSelectList { get; set; }
    }
}