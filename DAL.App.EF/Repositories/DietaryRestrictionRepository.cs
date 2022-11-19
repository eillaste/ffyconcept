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
using Microsoft.EntityFrameworkCore.Query;

namespace DAL.App.EF.Repositories
{
    public class DietaryRestrictionRepository: BaseRepository<DAL.App.DTO.DietaryRestriction,Domain.App.DietaryRestriction, AppDbContext>, IDietaryRestrictionRepository
    {
        public DietaryRestrictionRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new DietaryRestrictionMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.DietaryRestriction>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(r => r.FoodItem)
                .Include(r => r.Diet);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.DietaryRestriction?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
             query = query
                    .Include(r => r.FoodItem)
                    .Include(r => r.Diet);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

   
            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}