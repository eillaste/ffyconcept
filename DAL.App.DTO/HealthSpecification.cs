using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
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