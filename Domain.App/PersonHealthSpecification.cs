using System;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PersonHealthSpecification: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        public Guid HealthSpecificationId { get; set; }
        public virtual HealthSpecification? HealthSpecification { get; set; }
        
        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

    }
}