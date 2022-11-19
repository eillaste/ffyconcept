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

    public class DietaryRestrictionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private DietaryRestrictionMapper _dietaryRestrictionMapper;

        public DietaryRestrictionsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _dietaryRestrictionMapper = new DietaryRestrictionMapper(Mapper);
        }

        // GET: api/DietaryRestrictions
        /// <summary>
        /// Get all DietaryRestrictions
        /// </summary>
        /// <returns>List of DietaryRestrictions</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.DietaryRestriction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DietaryRestriction>>> GetDietaryRestrictions()
        {
            return await _context.DietaryRestrictions.ToListAsync();
        }

        // GET: api/DietaryRestrictions/5
        /// <summary>
        /// Get one DietaryRestriction, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>DietaryRestriction entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DietaryRestriction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DietaryRestriction>> GetDietaryRestriction(Guid id)
        {
            var dietaryRestriction = await _context.DietaryRestrictions.FindAsync(id);

            if (dietaryRestriction == null)
            {
                return NotFound();
            }

            return dietaryRestriction;
        }

        // PUT: api/DietaryRestrictions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one DietaryRestriction, Based on parameters: Id, DietaryRestriction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dietaryRestriction"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DietaryRestriction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutDietaryRestriction(Guid id, DietaryRestriction dietaryRestriction)
        {
            if (id != dietaryRestriction.Id)
            {
                return BadRequest();
            }

            _context.Entry(dietaryRestriction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietaryRestrictionExists(id))
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

        // POST: api/DietaryRestrictions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add DietaryRestriction, Based on request body: DietaryRestriction
        /// </summary>
        /// <param name="dietaryRestriction"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DietaryRestriction), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DietaryRestriction>> PostDietaryRestriction(DietaryRestriction dietaryRestriction)
        {
            _context.DietaryRestrictions.Add(dietaryRestriction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDietaryRestriction", new { id = dietaryRestriction.Id }, dietaryRestriction);
        }

        // DELETE: api/DietaryRestrictions/5
        /// <summary>
        /// Delete DietaryRestriction, Based on parameter: id
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
        public async Task<IActionResult> DeleteDietaryRestriction(Guid id)
        {
            var dietaryRestriction = await _context.DietaryRestrictions.FindAsync(id);
            if (dietaryRestriction == null)
            {
                return NotFound();
            }

            _context.DietaryRestrictions.Remove(dietaryRestriction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DietaryRestrictionExists(Guid id)
        {
            return _context.DietaryRestrictions.Any(e => e.Id == id);
        }
    }
}
*/
