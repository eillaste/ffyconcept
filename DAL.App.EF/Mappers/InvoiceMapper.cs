using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class InvoiceMapper: BaseMapper<DAL.App.DTO.Invoice, Domain.App.Invoice>,IBaseMapper<DAL.App.DTO.Invoice, Domain.App.Invoice>
    {
        public InvoiceMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}