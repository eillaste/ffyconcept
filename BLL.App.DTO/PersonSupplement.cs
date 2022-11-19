using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class PersonSupplement: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public double Quantity { get; set; }
    }
}