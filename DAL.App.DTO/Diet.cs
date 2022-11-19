using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
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