//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using StandardUnit = BLL.App.DTO.StandardUnit;


namespace WebApp.ViewModels
{
    public class StandardUnitCreateEditViewModel
    {
        public StandardUnit StandardUnit { get; set; } = default!;
    }
}