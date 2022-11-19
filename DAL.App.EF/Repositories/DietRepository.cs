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
    public class DietRepository: BaseRepository<DAL.App.DTO.Diet,Domain.App.Diet, AppDbContext>, IDietRepository
    {
        public DietRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new DietMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Diet>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(d => d.DietaryRestrictions)
                .ThenInclude(r => r.FoodItem);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Diet?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            query = query
                .Include(d => d.DietaryRestrictions)
                .ThenInclude(r => r.FoodItem);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}