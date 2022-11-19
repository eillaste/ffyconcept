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
    public class MenuRepository: BaseRepository<DAL.App.DTO.Menu,Domain.App.Menu, AppDbContext>, IMenuRepository
    {
        public MenuRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new MenuMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Menu>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

         //   query = query
        //        .Include(m => m.Restaurant)
          //      .Include(m => m.Recipes);
          var res = await resQuery.ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Menu?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

       //     query = query
        //        .Include(m => m.Restaurant)
        //        .Include(m => m.Recipes);

        var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
            return res;
        }
    }
}