using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using Restaurant = PublicApi.DTO.v1.Restaurant;

namespace PublicApi.DTO.v1
{
    public class MenuAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<PublicApi.DTO.v1.DishInMenu>? DisheInMenus { get; set; }
    }
    
    public class Menu: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;
        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<PublicApi.DTO.v1.DishInMenu>? DisheInMenus { get; set; }
    }
}