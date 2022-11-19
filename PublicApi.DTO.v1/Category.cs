using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class CategoryAddPut: DomainEntityId
    {
        //  public Guid Id { get; set; }
        [MaxLength(64)]
        public string Title { get; set; } = null!;

        //public virtual ICollection<FoodItem>? FoodItems { get; set; }
    }
    
    public class Category: DomainEntityId
    {
        //  public Guid Id { get; set; }
        [MaxLength(64)]
        public string Title { get; set; } = null!;

        //public virtual ICollection<FoodItem>? FoodItems { get; set; }
    }
}