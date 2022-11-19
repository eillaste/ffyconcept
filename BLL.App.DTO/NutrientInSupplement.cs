using System;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class NutrientInSupplement: DomainEntityId
    {

        public Guid SupplementId { get; set; }
        public virtual Supplement? Supplement { get; set; }

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }
    }
}