using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class AgeGroup: DomainEntityId
    {
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }

        public virtual  ICollection<RecommendedDietaryIntake>? RecommendedDietaryIntakes { get; set; }
        //public String? Range { get; set; }
    }
    
        
}