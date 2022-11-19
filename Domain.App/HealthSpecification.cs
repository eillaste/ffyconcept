using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class HealthSpecification: DomainEntityId
    {

        [MaxLength(128)]
        public string Title { get; set; } = null!;
        
        [MaxLength(256)]
        public string Description { get; set; } = null!;

        public virtual ICollection<PersonHealthSpecification>? PersonHealthSpecifications { get; set; }

        public virtual ICollection<HealthSpecificationNutrient>? HealthSpecificationNutrients { get; set; }
    }
}