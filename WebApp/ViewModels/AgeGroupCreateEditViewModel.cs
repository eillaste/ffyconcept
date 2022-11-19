//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgeGroup = BLL.App.DTO.AgeGroup;

namespace WebApp.ViewModels
{
    public class AgeGroupCreateEditViewModel
    {
        public AgeGroup AgeGroup { get; set; } = default!;
    }
}