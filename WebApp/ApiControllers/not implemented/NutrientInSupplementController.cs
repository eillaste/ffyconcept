/*
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PublicApi.DTO.v1.Mappers;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NutrientInSupplementController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private NutrientInSupplementMapper _nutrientInSupplementMapper;

        public NutrientInSupplementController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _nutrientInSupplementMapper = new NutrientInSupplementMapper(Mapper);
        }

        // GET: api/NutrientInSupplement
        /// <summary>
        /// Get all NutrientInSupplement
        /// </summary>
        /// <returns>List of NutrientInSupplement</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.NutrientInSupplement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<NutrientInSupplement>>> GetNutrientInSupplement()
        {
            return await _context.NutrientInSupplement.ToListAsync();
        }

        // GET: api/NutrientInSupplement/5
        /// <summary>
        /// Get one NutrientInSupplement, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>NutrientInSupplement entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.NutrientInSupplement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<NutrientInSupplement>> GetNutrientInSupplement(Guid id)
        {
            var nutrientInSupplement = await _context.NutrientInSupplement.FindAsync(id);

            if (nutrientInSupplement == null)
            {
                return NotFound();
            }

            return nutrientInSupplement;
        }

        // PUT: api/NutrientInSupplement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one NutrientInSupplement, Based on parameters: Id, NutrientInSupplement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nutrientInSupplement"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.NutrientInSupplement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutNutrientInSupplement(Guid id, NutrientInSupplement nutrientInSupplement)
        {
            if (id != nutrientInSupplement.Id)
            {
                return BadRequest();
            }

            _context.Entry(nutrientInSupplement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutrientInSupplementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NutrientInSupplement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add NutrientInSupplement, Based on request body: NutrientInSupplement
        /// </summary>
        /// <param name="nutrientInSupplement"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.NutrientInSupplement), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<NutrientInSupplement>> PostNutrientInSupplement(NutrientInSupplement nutrientInSupplement)
        {
            _context.NutrientInSupplement.Add(nutrientInSupplement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNutrientInSupplement", new { id = nutrientInSupplement.Id }, nutrientInSupplement);
        }

        // DELETE: api/NutrientInSupplement/5
        /// <summary>
        /// Delete NutrientInSupplement, Based on parameter: id
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
        public async Task<IActionResult> DeleteNutrientInSupplement(Guid id)
        {
            var nutrientInSupplement = await _context.NutrientInSupplement.FindAsync(id);
            if (nutrientInSupplement == null)
            {
                return NotFound();
            }

            _context.NutrientInSupplement.Remove(nutrientInSupplement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NutrientInSupplementExists(Guid id)
        {
            return _context.NutrientInSupplement.Any(e => e.Id == id);
        }
    }
}
*/
