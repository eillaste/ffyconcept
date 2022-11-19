using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using DietaryRestriction = PublicApi.DTO.v1.DietaryRestriction;
using PersonDiet = PublicApi.DTO.v1.PersonDiet;

namespace PublicApi.DTO.v1
{
    public class DietAddPut: DomainEntityId
    {

        [MaxLength(64)]
        public string Title { get; set; } = null!;
        
        [MaxLength(256)]
        public string Description { get; set; } = null!;

        public virtual ICollection<PersonDiet>? PersonDiets { get; set; }

        public virtual ICollection<DietaryRestriction>? DietaryRestrictions { get; set; }
    }
    
    public class Diet: DomainEntityId
    {

        [MaxLength(64)]
        public string Title { get; set; } = null!;
        
        [MaxLength(256)]
        public string Description { get; set; } = null!;

        public virtual ICollection<PersonDiet>? PersonDiets { get; set; }

        public virtual ICollection<DietaryRestriction>? DietaryRestrictions { get; set; }
    }
}