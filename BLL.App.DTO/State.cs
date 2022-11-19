using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class State: DomainEntityId
    {

        [MaxLength(32)]
        public string StateTitle { get; set; } = null!;

        public DateTime ModificationTime { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}