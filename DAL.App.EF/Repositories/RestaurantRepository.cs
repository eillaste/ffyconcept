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
    public class RestaurantRepository: BaseRepository<DAL.App.DTO.Restaurant,Domain.App.Restaurant, AppDbContext>, IRestaurantRepository
    {
        public RestaurantRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new RestaurantMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Restaurant>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }
            //query = query
                //.Include(r => r.Company);
                //.Include(r=>r.Menus)
                //.Include(r=>r.Orders);
                var res = await resQuery.ToListAsync();
                return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Restaurant?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            //query = query
              //  .Include(r => r.Company);


              var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
              return res;
        }
    }
}