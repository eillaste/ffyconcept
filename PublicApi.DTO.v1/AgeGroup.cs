using System;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class AgeGroupAddPut: DomainEntityId
    {
        // public new Guid Id { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
    }
    
    
    public class AgeGroup: DomainEntityId
    {
        /*public int LowerBound { get; set; }
        public int UpperBound { get; set; }*/
        // public Guid Id { get; set; }
        public String Range { get; set; } = default!;
    }
}
