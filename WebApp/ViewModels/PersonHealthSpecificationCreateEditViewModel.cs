//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PersonHealthSpecificationCreateEditViewModel
    {
        public PersonHealthSpecification PersonHealthSpecification { get; set; } = default!;

        public SelectList? HealthSpecificationSelectList { get; set; }
    }
}