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
    public class NutrientInSupplementRepository: BaseRepository<DAL.App.DTO.NutrientInSupplement,Domain.App.NutrientInSupplement, AppDbContext>, INutrientInSupplementRepository
    {
        public NutrientInSupplementRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new NutrientInSupplementMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.NutrientInSupplement>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(n => n.Nutrient)
                .Include(n => n.Supplement);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.NutrientInSupplement?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(n => n.Nutrient)
                .Include(n => n.Supplement);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}