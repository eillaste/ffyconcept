using System;
using DAL.App.DTO.Identity;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class DishInOrder: DomainEntityId
    {

        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid DishInMenuId { get; set; }
        public virtual DishInMenu? DishInMenu { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}