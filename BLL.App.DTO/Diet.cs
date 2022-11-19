using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
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