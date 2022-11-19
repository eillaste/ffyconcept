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
    public class IngredientRepository: BaseRepository<DAL.App.DTO.Ingredient,Domain.App.Ingredient, AppDbContext>, IIngredientRepository
    {
        public IngredientRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new IngredientMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Ingredient>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(i => i.FoodItem)
                .Include(i => i.Recipe);
           
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Ingredient?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            /*
            query = query
                .Include(i => i.FoodItem)
                .Include(i => i.Recipe);
                */

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
    }
}