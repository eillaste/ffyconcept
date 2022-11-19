using System;
using Domain.Base;
using Supplement = BLL.App.DTO.Supplement;

namespace PublicApi.DTO.v1
{
    public class NutrientInSupplementAddPut: DomainEntityId
    {

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public Guid NutrientId { get; set; }
        public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
    
    public class NutrientInSupplement: DomainEntityId
    {

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public Guid NutrientId { get; set; }
        public virtual PublicApi.DTO.v1.Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
}