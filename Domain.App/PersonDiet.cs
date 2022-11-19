using System;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PersonDiet: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;

        public Guid DietId { get; set; }
        public virtual Diet? Diet { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}