using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using Supplement = BLL.App.DTO.Supplement;

namespace PublicApi.DTO.v1
{
    public class PersonSupplementAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public double Quantity { get; set; }
    }
    
    public class PersonSupplement: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public double Quantity { get; set; }
    }
}