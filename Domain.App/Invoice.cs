using System;
using Domain.Base;

namespace Domain.App
{
    public class Invoice: DomainEntityId
    {

        //public Guid CompanyId { get; set; }
        //public Company? Company { get; set; }
        
        //public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public DateTime PaymentDeadline { get; set; }
    }
}