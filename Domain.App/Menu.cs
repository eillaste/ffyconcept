using System;
using System.Collections.Generic;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class Menu: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;
        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<DishInMenu>? DisheInMenus { get; set; }
    }
}