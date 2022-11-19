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
    public class DishInOrderRepository: BaseRepository<DAL.App.DTO.DishInOrder,Domain.App.DishInOrder, AppDbContext>, IDishInOrderRepository
    {
        public DishInOrderRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new DishInOrderMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.DishInOrder>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            query = query
                .Include(d => d.DishInMenu)
                .ThenInclude(m => m!.Recipe)
                .Include(d => d.Order);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.DishInOrder?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(d => d.DishInMenu)
                .ThenInclude(m => m!.Recipe)
                .Include(d => d.Order);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
    }
}