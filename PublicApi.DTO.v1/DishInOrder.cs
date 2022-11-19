using System;
using BLL.App.DTO.Identity;
using Domain.Base;
using Order = PublicApi.DTO.v1.Order;

namespace PublicApi.DTO.v1
{
    public class DishInOrderAddPut: DomainEntityId
    {

        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid DishInMenuId { get; set; }
        public virtual PublicApi.DTO.v1.DishInMenu? DishInMenu { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
    
    public class DishInOrder: DomainEntityId
    {

        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid DishInMenuId { get; set; }
        public virtual PublicApi.DTO.v1.DishInMenu? DishInMenu { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}