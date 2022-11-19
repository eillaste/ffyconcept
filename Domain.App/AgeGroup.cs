using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.App
{
    public class AgeGroup: DomainEntityId
    {
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }

        public virtual  ICollection<RecommendedDietaryIntake>? RecommendedDietaryIntakes { get; set; }
    }
}