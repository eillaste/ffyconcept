using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using HealthSpecificationNutrient = PublicApi.DTO.v1.HealthSpecificationNutrient;
using PersonHealthSpecification = PublicApi.DTO.v1.PersonHealthSpecification;

namespace PublicApi.DTO.v1
{
    public class HealthSpecificationAddPut: DomainEntityId
    {

        [MaxLength(128)]
        public string Title { get; set; } = null!;
        
        [MaxLength(256)]
        public string Description { get; set; } = null!;

        public virtual ICollection<PersonHealthSpecification>? PersonHealthSpecifications { get; set; }

        public virtual ICollection<HealthSpecificationNutrient>? HealthSpecificationNutrients { get; set; }
    }
    
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