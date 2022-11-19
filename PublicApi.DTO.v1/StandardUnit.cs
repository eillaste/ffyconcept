using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Supplement = BLL.App.DTO.Supplement;

namespace PublicApi.DTO.v1
{
    public class StandardUnitAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }

        [MaxLength(32)]
        public string? Title { get; set; }

        [MaxLength(4)]
        public string? Symbol { get; set; }

        /*public virtual ICollection<PublicApi.DTO.v1.FoodItem>? FoodItems { get; set; }
        public virtual ICollection<Supplement>? Supplements { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Nutrient>? Nutrients { get; set; }*/
    }
    
    public class StandardUnit: DomainEntityId
    {
        // public Guid Id { get; set; }
        [MaxLength(32)]
        public string? Title { get; set; }

        [MaxLength(4)]
        public string? Symbol { get; set; }

        /*
        public virtual ICollection<PublicApi.DTO.v1.FoodItem>? FoodItems { get; set; }
        public virtual ICollection<Supplement>? Supplements { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Nutrient>? Nutrients { get; set; }
    */
    }
}