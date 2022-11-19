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
    public class DishInMenuRepository: BaseRepository<DAL.App.DTO.DishInMenu,Domain.App.DishInMenu, AppDbContext>, IDishInMenuRepository
    {
        public DishInMenuRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new DishInMenuMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.DishInMenu>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            query = query
                .Include(d => d.Menu)
                .Include(d => d.Recipe);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.DishInMenu?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            query = query
                .Include(d => d.Menu)
                .Include(d => d.Recipe);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}