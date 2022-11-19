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
    public class TolerableUpperIntakeLevelsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private TolerableUpperIntakeLevelMapper _tolerableUpperIntakeLevelMapper;

        public TolerableUpperIntakeLevelsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _tolerableUpperIntakeLevelMapper = new TolerableUpperIntakeLevelMapper(Mapper);
        }

        // GET: api/TolerableUpperIntakeLevels
        /// <summary>
        /// Get all TolerableUpperIntakeLevels
        /// </summary>
        /// <returns>List of TolerableUpperIntakeLevels</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.TolerableUpperIntakeLevel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.TolerableUpperIntakeLevel>>> GetTolerableUpperIntakeLevel()
        {
            return Ok((await _bll.TolerableUpperIntakeLevels.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.TolerableUpperIntakeLevel, PublicApi.DTO.v1.TolerableUpperIntakeLevel>(s)
));
        }

        // GET: api/TolerableUpperIntakeLevels/5
        /// <summary>
        /// Get one TolerableUpperIntakeLevel, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>TolerableUpperIntakeLevel entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.TolerableUpperIntakeLevel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.TolerableUpperIntakeLevel>> GetTolerableUpperIntakeLevel(Guid id)
        {
            var tolerableUpperIntakeLevel = await _bll.TolerableUpperIntakeLevels.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (tolerableUpperIntakeLevel == null)
            {
                return NotFound();
            }
            /*var res = new PublicApi.DTO.v1.TolerableUpperIntakeLevel()
            {
                Id = tolerableUpperIntakeLevel.Id,
                NutrientId = tolerableUpperIntakeLevel.NutrientId,
                Quantity = tolerableUpperIntakeLevel.Quantity
            };*/
            return Mapper.Map<BLL.App.DTO.TolerableUpperIntakeLevel, PublicApi.DTO.v1.TolerableUpperIntakeLevel>(tolerableUpperIntakeLevel);
        }

        // PUT: api/TolerableUpperIntakeLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one TolerableUpperIntakeLevel, Based on parameters: Id, TolerableUpperIntakeLevel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tolerableUpperIntakeLevel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.TolerableUpperIntakeLevel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutTolerableUpperIntakeLevel(Guid id, PublicApi.DTO.v1.TolerableUpperIntakeLevelAddPut tolerableUpperIntakeLevel)
        {
            if (id != tolerableUpperIntakeLevel.Id)
            {
                return BadRequest();
            }

            var bllTolerableUpperIntakeLevel = TolerableUpperIntakeLevelMapper.MapToBll(tolerableUpperIntakeLevel);

            _bll.TolerableUpperIntakeLevels.Update(bllTolerableUpperIntakeLevel);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TolerableUpperIntakeLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add TolerableUpperIntakeLevel, Based on request body: TolerableUpperIntakeLevel
        /// </summary>
        /// <param name="tolerableUpperIntakeLevel"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.TolerableUpperIntakeLevel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<TolerableUpperIntakeLevel>> PostTolerableUpperIntakeLevel(PublicApi.DTO.v1.TolerableUpperIntakeLevelAddPut tolerableUpperIntakeLevel)
        {
            var bllTolerableUpperIntakeLevel = TolerableUpperIntakeLevelMapper.MapToBll(tolerableUpperIntakeLevel);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedTolerableUpperIntakeLevel = _bll.TolerableUpperIntakeLevels.Add(bllTolerableUpperIntakeLevel);
            await _bll.SaveChangesAsync();
            var returnTolerableUpperIntakeLevel = _tolerableUpperIntakeLevelMapper.Map(addedTolerableUpperIntakeLevel);
            
            // this is sketchy af
            //returnAgeGroup!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetTolerableUpperIntakeLevel", new {id = returnTolerableUpperIntakeLevel!.Id}, returnTolerableUpperIntakeLevel);
        }

        // DELETE: api/TolerableUpperIntakeLevels/5
        /// <summary>
        /// Delete TolerableUpperIntakeLevel, Based on parameter: id
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
        public async Task<IActionResult> DeleteTolerableUpperIntakeLevel(Guid id)
        {
            var tolerableUpperIntakeLevel = await _bll.TolerableUpperIntakeLevels.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (tolerableUpperIntakeLevel == null)
            {
                return NotFound();
            }

            _bll.TolerableUpperIntakeLevels.Remove(tolerableUpperIntakeLevel);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> TolerableUpperIntakeLevelExists(Guid id)
        {
            return await _bll.TolerableUpperIntakeLevels.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
