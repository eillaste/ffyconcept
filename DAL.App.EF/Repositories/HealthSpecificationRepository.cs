using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using Contracts.Domain.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HealthSpecificationRepository: BaseRepository<DAL.App.DTO.HealthSpecification,Domain.App.HealthSpecification, AppDbContext>, IHealthSpecificationRepository
    {
        public HealthSpecificationRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new HealthSpecificationMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.HealthSpecification>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

            var res = await resQuery.ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.HealthSpecification?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            //query=

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
            return res;
        }
    }
}