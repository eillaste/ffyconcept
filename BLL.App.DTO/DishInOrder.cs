using System;
using BLL.App.DTO.Identity;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
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