using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class InvoiceMapper: BaseMapper<BLL.App.DTO.Invoice, DAL.App.DTO.Invoice>,IBaseMapper<BLL.App.DTO.Invoice, DAL.App.DTO.Invoice>
    {
        public InvoiceMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}