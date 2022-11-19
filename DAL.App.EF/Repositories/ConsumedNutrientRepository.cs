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
using ConsumedNutrient = DAL.App.DTO.ConsumedNutrient;

namespace DAL.App.EF.Repositories
{
    public class ConsumedNutrientRepository: BaseRepository<DAL.App.DTO.ConsumedNutrient,Domain.App.ConsumedNutrient, AppDbContext>, IConsumedNutrientRepository
    {
        public ConsumedNutrientRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new ConsumedNutrientMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.ConsumedNutrient>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            query = query
                .Include(c => c.Nutrient)
                .Include(c => c.AppUser);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            
            if (userId != default)
            {
                query = query.Where(c => c.AppUserId == userId);
            }
            
            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.ConsumedNutrient?> FirstOrDefaultAsync(Guid id,Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }

        public async Task<DAL.App.DTO.ConsumedNutrient?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
                        
            query = query
                .Include(c => c.Nutrient)
                .Include(c => c.AppUser);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
        
        public async Task<IEnumerable<DAL.App.DTO.ConsumedNutrient>> GetAllWithNutrientDateAndQuantityAsync(Guid userId, bool noTracking = true)
        {
            {
                var query = CreateQuery(userId, noTracking);
                var resQuery = query.Select(consumedNutrient => new DAL.App.DTO.ConsumedNutrient()
                    {
                        Id = consumedNutrient.Id,
                        NutrientId = consumedNutrient.NutrientId,
                        NutrientName = consumedNutrient.Nutrient!.Title,
                        Date = consumedNutrient.Date,
                        Quantity = consumedNutrient.Quantity
                    })
                    .OrderBy(x => x.Date);
                

                var res = await resQuery.ToListAsync();
                return res;
            }
        }


    }
}