//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class HealthSpecificationCreateEditViewModel
    {
        public HealthSpecification HealthSpecification { get; set; } = default!;   
    }
}