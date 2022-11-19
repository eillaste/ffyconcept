using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;

namespace BLL.App.DTO
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