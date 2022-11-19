//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PersonDietCreateEditViewModel
    {
        public PersonDiet PersonDiet { get; set; } = default!;

        public SelectList? DietSelectList { get; set; }
    }
}