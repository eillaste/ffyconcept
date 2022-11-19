using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class InvoiceMapper : BaseMapper<PublicApi.DTO.v1.Invoice, BLL.App.DTO.Invoice>
    {
        public InvoiceMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Invoice MapToBll(InvoiceAddPut invoiceAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Invoice()
            {

            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}