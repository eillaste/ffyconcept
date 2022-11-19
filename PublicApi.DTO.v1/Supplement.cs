using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class SupplementAddPut: DomainEntityId
    {

        public Guid StandardUnitId { get; set; }
        public virtual PublicApi.DTO.v1.StandardUnit? StandardUnit { get; set; }

        [MaxLength(64)]
        public string Title { get; set; } = null!;

        public virtual ICollection<PublicApi.DTO.v1.NutrientInSupplement>? NutrientInSupplements { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.PersonSupplement>? PersonSupplements { get; set; }
    }
    
    public class Supplement: DomainEntityId
    {

        public Guid StandardUnitId { get; set; }
        public virtual PublicApi.DTO.v1.StandardUnit? StandardUnit { get; set; }

        [MaxLength(64)]
        public string Title { get; set; } = null!;

        public virtual ICollection<PublicApi.DTO.v1.NutrientInSupplement>? NutrientInSupplements { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.PersonSupplement>? PersonSupplements { get; set; }
    }
}