using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class StatsAddPut: DomainEntityId
    {

        // public Guid Id { get; set; }
        public DateTime Time { get; set; }
    }
    
    public class Stats: DomainEntityId
    {

        // public Guid Id { get; set; }
        public DateTime Time { get; set; }
    }
}