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
    public class PersonHealthSpecificationRepository: BaseRepository<DAL.App.DTO.PersonHealthSpecification,Domain.App.PersonHealthSpecification, AppDbContext>, IPersonHealthSpecificationRepository
    {
        public PersonHealthSpecificationRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new PersonHealthSpecificationMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.PersonHealthSpecification>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(p => p.AppUser)
                .Include(p => p.HealthSpecification);
            
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
        
        

        public override async Task<DAL.App.DTO.PersonHealthSpecification?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(p => p.AppUser)
                .Include(p => p.HealthSpecification);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
    }
}