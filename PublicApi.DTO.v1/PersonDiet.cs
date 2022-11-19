using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class PersonDietAddPut: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;

        public Guid DietId { get; set; }
        public virtual PublicApi.DTO.v1.Diet? Diet { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    
    public class PersonDiet: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;

        public Guid DietId { get; set; }
        public virtual PublicApi.DTO.v1.Diet? Diet { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}