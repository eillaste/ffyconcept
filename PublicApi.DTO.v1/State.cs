using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class StateAddPut: DomainEntityId
    {

        [MaxLength(32)]
        public string StateTitle { get; set; } = null!;

        public DateTime ModificationTime { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Order>? Orders { get; set; }
    }
    
    public class State: DomainEntityId
    {

        [MaxLength(32)]
        public string StateTitle { get; set; } = null!;

        public DateTime ModificationTime { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Order>? Orders { get; set; }
    }
}