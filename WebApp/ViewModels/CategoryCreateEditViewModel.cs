//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Category = BLL.App.DTO.Category;

namespace WebApp.ViewModels
{
    public class CategoryCreateEditViewModel
    {
        public Category Category { get; set; } = default!; 
    }
}