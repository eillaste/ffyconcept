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
    public class StateRepository: BaseRepository<DAL.App.DTO.State,Domain.App.State, AppDbContext>, IStateRepository
    {
        public StateRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new StateMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.State>> GetAllAsync(Guid userId, bool noTracking = true)
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
        
        

        public override async Task<DAL.App.DTO.State?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }


            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
            return res;
        }
    }
}