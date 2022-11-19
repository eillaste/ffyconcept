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

    public class NutrientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private NutrientMapper _nutrientMapper;

        public NutrientsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _nutrientMapper = new NutrientMapper(Mapper);
        }

        // GET: api/Nutrients
        /// <summary>
        /// Get all Nutrients
        /// </summary>
        /// <returns>List of Nutrients</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Nutrient>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Nutrient>>> GetNutrients()
        {
            return Ok((await _bll.Nutrients.GetAllAsync()).Select(s => Mapper.Map<BLL.App.DTO.Nutrient, PublicApi.DTO.v1.Nutrient>(s)));
            
            
        }

        // GET: api/Nutrients/5
        /// <summary>
        /// Get one Nutrient, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>Nutrient entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Nutrient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.Nutrient>> GetNutrient(Guid id)
        {
            var nutrient = await _bll.Nutrients.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (nutrient == null)
            {
                return NotFound();
            }
            
            /*var res = new PublicApi.DTO.v1.Nutrient()
            {
                Id = nutrient.Id,
                StandardUnitId = nutrient.StandardUnitId,
                Title = nutrient.Title
            };*/

            return Mapper.Map<BLL.App.DTO.Nutrient, PublicApi.DTO.v1.Nutrient>(nutrient);
        }

        // PUT: api/Nutrients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one Nutrient, Based on parameters: Id, Nutrient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nutrient"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Nutrient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutNutrient(Guid id, PublicApi.DTO.v1.NutrientAddPut nutrient)
        {
            if (id != nutrient.Id)
            {
                return BadRequest();
            }

            var bllNutrient = NutrientMapper.MapToBll(nutrient);

            _bll.Nutrients.Update(bllNutrient);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Nutrients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Nutrient, Based on request body: Nutrient
        /// </summary>
        /// <param name="nutrient"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Nutrient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Nutrient>> PostNutrient(PublicApi.DTO.v1.NutrientAddPut nutrient)
        {
            var bllNutrient = NutrientMapper.MapToBll(nutrient);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedNutrient = _bll.Nutrients.Add(bllNutrient);
            await _bll.SaveChangesAsync();
            var returnNutrient = _nutrientMapper.Map(addedNutrient);
            
            // this is sketchy af
            //returnAgeGroup!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetNutrient", new {id = returnNutrient!.Id}, returnNutrient);
        }

        // DELETE: api/Nutrients/5
        /// <summary>
        /// Delete Nutrient, Based on parameter: id
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
        public async Task<IActionResult> DeleteNutrient(Guid id)
        {
            var nutrient = await _bll.Nutrients.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (nutrient == null)
            {
                return NotFound();
            }

            _bll.Nutrients.Remove(nutrient);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AgeGroupExists(Guid id)
        {
            return await _bll.Nutrients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
