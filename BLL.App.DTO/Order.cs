using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Order: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;

        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        public Guid InvoiceId { get; set; }
        public virtual Invoice? Invoice { get; set; }

        public Guid StateId { get; set; }
        public virtual State? State { get; set; }

        [MaxLength(256)]
        public string Comment { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public DateTime ReadyTime { get; set; }

        public virtual ICollection<DishInOrder>? DishInOrders { get; set; }
    }
}