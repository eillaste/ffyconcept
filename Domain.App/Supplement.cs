using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Supplement: DomainEntityId
    {

        public Guid StandardUnitId { get; set; }
        public virtual StandardUnit? StandardUnit { get; set; }

        [MaxLength(64)]
        public string Title { get; set; } = null!;

        public virtual ICollection<NutrientInSupplement>? NutrientInSupplements { get; set; }
        public virtual ICollection<PersonSupplement>? PersonSupplements { get; set; }
    }
}