using System;
using System.Collections.Generic;
using DAL.App.DTO.Identity;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class DishInMenu: DomainEntityId
    {

        public Guid RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }
        

        public Guid MenuId { get; set; }
        public virtual Menu? Menu { get; set; }

        public double Price { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<DishInOrder>? DishInOrders { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}