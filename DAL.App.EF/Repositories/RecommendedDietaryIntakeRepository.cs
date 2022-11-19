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
    public class RecommendedDietaryIntakeRepository: BaseRepository<DAL.App.DTO.RecommendedDietaryIntake,Domain.App.RecommendedDietaryIntake, AppDbContext>, IRecommendedDietaryIntakeRepository
    {
        public RecommendedDietaryIntakeRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new RecommendedDietaryIntakeMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.RecommendedDietaryIntake>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(r=>r.AgeGroup)
                .Include(r=>r.Nutrient);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.RecommendedDietaryIntake?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(r=>r.AgeGroup)
                .Include(r=>r.Nutrient);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}