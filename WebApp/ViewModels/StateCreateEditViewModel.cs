//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class StateCreateEditViewModel
    {
        public State State { get; set; } = default!;
    }
}