using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class RestaurantAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {



        public double Lat { get; set; }
        public double Lng { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual ICollection<PublicApi.DTO.v1.Order>? Orders { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Menu>? Menus { get; set; }
        
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
    }
    
    public class Restaurant: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {



        public double Lat { get; set; }
        public double Lng { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual ICollection<PublicApi.DTO.v1.Order>? Orders { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Menu>? Menus { get; set; }
        
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
    }
}