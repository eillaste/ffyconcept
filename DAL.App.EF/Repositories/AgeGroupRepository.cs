using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories

{
    public class AgeGroupRepository : BaseRepository<DAL.App.DTO.AgeGroup,Domain.App.AgeGroup , AppDbContext>,IAgeGroupRepository
    {
        public AgeGroupRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new AgeGroupMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.AgeGroup>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

            var res = await resQuery.ToListAsync();
            return res!;
        }

        public override async Task<DAL.App.DTO.AgeGroup?> FirstOrDefaultAsync(Guid id,Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            //var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m!.Id == id);
            return Mapper.Map(res);
        }

        public async Task<IEnumerable<DAL.App.DTO.AgeGroup>> GetAllWithRangeAsync(bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);

            var resQuery = query.Select(ageGroup => new DAL.App.DTO.AgeGroup()
            {
                Id = ageGroup.Id, 
                //Range = ageGroup.LowerBound.ToString() + "-" + ageGroup.UpperBound.ToString()
            });

            var res = await resQuery.ToListAsync();
            return res;
        }

        public async Task<DAL.App.DTO.AgeGroup?> FirstOrDefaultWithIncludesAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }

        public async Task<DAL.App.DTO.AgeGroup?> GetOneAsync(Guid id,Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }


            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
            return res;
        }
    }
}

        
                
/*
public override async Task<IEnumerable<AgeGroup>> GetAllAsyncNoGuid()
{
    var query = RepoDbSet.AsQueryable();


    var res = await query.ToListAsync();
    return res;
}*/
