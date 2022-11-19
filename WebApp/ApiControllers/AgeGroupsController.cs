using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
//using DTO.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PublicApi.DTO.v1.Mappers;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AgeGroupsController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private AgeGroupMapper _ageGroupMapper;
        public AgeGroupsController(IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            //_context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _ageGroupMapper = new AgeGroupMapper(Mapper);
        }

        // GET: api/AgeGroups
        /// <summary>
        /// Get all AgeGroups
        /// </summary>
        /// <returns>List of AgeGroups</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.AgeGroup>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.AgeGroup>>> GetAgeGroups()
        {
            return Ok((await _bll.AgeGroups.GetAllAsync()).Select(s => new PublicApi.DTO.v1.AgeGroup()
            {
                Id = s.Id,
                Range = s.LowerBound + "-" + s.UpperBound
            }));

            
            /*
            var res = await _bll.AgeGroups.GetAllWithRangeAsync();
            return Ok(res);*/
        }

        // GET: api/AgeGroups
        /// <summary>
        /// Get one AgeGroup, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>AgeGroup entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.AgeGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.AgeGroup>> GetAgeGroup(Guid id)
        {
            var ageGroup = await _bll.AgeGroups.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (ageGroup == null)
            {
                return NotFound();
            }

            var res = new PublicApi.DTO.v1.AgeGroup()
            {
                Id = ageGroup.Id,
                Range = ageGroup.LowerBound + "-" + ageGroup.UpperBound
            };
            

            return res;
        }

        // PUT: api/AgeGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one AgeGroup, Based on parameters: Id, AgeGroup
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ageGroup"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.AgeGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutAgeGroup(Guid id, PublicApi.DTO.v1.AgeGroupAddPut ageGroup)
        {
            Console.WriteLine("Trying to put" + ageGroup.Id);
            if (id != ageGroup.Id)
            {
                return BadRequest();
            }
            
            var bllAgeGroup = AgeGroupMapper.MapToBll(ageGroup);

            _bll.AgeGroups.Update(bllAgeGroup);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
        // POST: api/AgeGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add AgeGroup, Based on request body: AgeGroup
        /// </summary>
        /// <param name="ageGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.AgeGroup), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.AgeGroup>> PostAgeGroup(PublicApi.DTO.v1.AgeGroupAddPut ageGroup)
        {
            var bllAgeGroup = AgeGroupMapper.MapToBll(ageGroup);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedAgeGroup = _bll.AgeGroups.Add(bllAgeGroup);
            await _bll.SaveChangesAsync();
            var returnAgeGroup = _ageGroupMapper.Map(addedAgeGroup);
            
            // this is sketchy af
            returnAgeGroup!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetAgeGroup", new {id = returnAgeGroup!.Id}, returnAgeGroup);
        }

        // DELETE: api/AgeGroups/5
        /// <summary>
        /// Delete AgeGroup, Based on parameter: id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAgeGroup(Guid id)
        {
            var ageGroup = await _bll.AgeGroups.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (ageGroup == null)
            {
                return NotFound();
            }
            _bll.AgeGroups.Remove(ageGroup);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AgeGroupExists(Guid id)
        {
            return await _bll.AgeGroups.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
