using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Category: DomainEntityId
    {
        
        [MaxLength(64)]
        public string Title { get; set; } = null!;

        public virtual ICollection<FoodItem>? FoodItems { get; set; }
    }
}