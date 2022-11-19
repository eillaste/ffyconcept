using System;
using Contracts.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
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