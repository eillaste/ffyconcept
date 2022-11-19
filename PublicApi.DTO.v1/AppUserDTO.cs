using System;
using Domain.App;
using Domain.Base;

namespace PublicApi.DTO.v1
{
    public class AppUserDTOAddPut: DomainEntityId
    {
        //  public Guid Id { get; set; }
        public DateTime Born { get; set; }
        public EGender Gender { get; set; }
    }
    
    
    public class AppUserDTO: DomainEntityId
    {
        //  public Guid Id { get; set; }
        public DateTime Born { get; set; }
        public EGender Gender { get; set; }
    }
}