using System;
using Domain.Base;

//using Domain.App;

namespace PublicApi.DTO.v1
{
    
    public class ConsumedFoodItemAddPut: DomainEntityId
    {
        //  public Guid Id { get; set; }
        public Guid FoodItemId { get; set; }
        public Guid AppUserId { get; set; }
        public String FoodItem { get; set; } = default!; 
        public DateTime Date  { get; set; }
        public double Quantity { get; set; }
    }
    public class ConsumedFoodItem: DomainEntityId
    {
        //  public Guid Id { get; set; }
        public Guid FoodItemId { get; set; }
        public virtual String FoodItem { get; set; } = default!;

        public DateTime Date { get; set; }
        
        public double Quantity { get; set; }
    }
}

/*
using System;

namespace PublicApi.DTO.v1
{
    public class AgeGroupAddPut
    {
        public Guid Id { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
    }
    
    
    public class AgeGroup
    {
        /*public int LowerBound { get; set; }
        public int UpperBound { get; set; }#1#
        public Guid Id { get; set; }
        public String Range { get; set; } = default!;
    }
}
*/
