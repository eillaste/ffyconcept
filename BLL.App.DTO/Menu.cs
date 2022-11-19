using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Menu: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<DishInMenu>? DisheInMenus { get; set; }
    }
}