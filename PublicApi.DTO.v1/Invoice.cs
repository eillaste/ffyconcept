using System;
using Domain.Base;
using Order = PublicApi.DTO.v1.Order;

namespace PublicApi.DTO.v1
{
    
    public class InvoiceAddPut: DomainEntityId
    {

        //public Guid CompanyId { get; set; }
        //public Company? Company { get; set; }
        
        //public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public DateTime PaymentDeadline { get; set; }
    }
    public class Invoice: DomainEntityId
    {

        //public Guid CompanyId { get; set; }
        //public Company? Company { get; set; }
        
        //public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public DateTime PaymentDeadline { get; set; }
    }
}