//using Domain.App;

using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class OrderCreateEditViewModel
    {
        public Order Order { get; set; } = default!;
        public SelectList? RestaurantSelectList { get; set; }
        public SelectList? InvoiceSelectList { get; set; }
        public SelectList? StateSelectList { get; set; }
    }
}