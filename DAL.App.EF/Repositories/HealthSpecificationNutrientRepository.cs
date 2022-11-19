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
    public class HealthSpecificationNutrientRepository: BaseRepository<DAL.App.DTO.HealthSpecificationNutrient,Domain.App.HealthSpecificationNutrient, AppDbContext>, IHealthSpecificationNutrientRepository
    {
        public HealthSpecificationNutrientRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new HealthSpecificationNutrientMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.HealthSpecificationNutrient>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            query = query
                .Include(h => h.HealthSpecification)
                .Include(h => h.Nutrient);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.HealthSpecificationNutrient?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(h => h.HealthSpecification)
                .Include(h => h.Nutrient);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}