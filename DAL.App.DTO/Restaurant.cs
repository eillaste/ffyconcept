using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Restaurant: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {



        public double Lat { get; set; }
        public double Lng { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Menu>? Menus { get; set; }
        
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
    }
}