//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class TagCreateEditViewModel
    {
        public Tag Tag { get; set; } = default!;
    }
}