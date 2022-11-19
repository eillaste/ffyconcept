using System;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
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