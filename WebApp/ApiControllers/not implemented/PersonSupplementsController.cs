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
    [Authorize(Roles="customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonSupplementsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonSupplementMapper _personSupplementMapper;

        public PersonSupplementsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personSupplementMapper = new PersonSupplementMapper(Mapper);
        }

        // GET: api/PersonSupplements
        /// <summary>
        /// Get all PersonSupplements
        /// </summary>
        /// <returns>List of PersonSupplements</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonSupplement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PersonSupplement>>> GetPersonSupplements()
        {
            return await _context.PersonSupplements.ToListAsync();
        }

        // GET: api/PersonSupplements/5
        /// <summary>
        /// Get one PersonSupplement, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>PersonSupplement entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonSupplement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonSupplement>> GetPersonSupplement(Guid id)
        {
            var personSupplement = await _context.PersonSupplements.FindAsync(id);

            if (personSupplement == null)
            {
                return NotFound();
            }

            return personSupplement;
        }

        // PUT: api/PersonSupplements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one PersonSupplement, Based on parameters: Id, PersonSupplement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personSupplement"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonSupplement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonSupplement(Guid id, PersonSupplement personSupplement)
        {
            if (id != personSupplement.Id)
            {
                return BadRequest();
            }

            _context.Entry(personSupplement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonSupplementExists(id))
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

        // POST: api/PersonSupplements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add PersonSupplement, Based on request body: PersonSupplement
        /// </summary>
        /// <param name="personSupplement"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonSupplement), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonSupplement>> PostPersonSupplement(PersonSupplement personSupplement)
        {
            _context.PersonSupplements.Add(personSupplement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonSupplement", new { id = personSupplement.Id }, personSupplement);
        }

        // DELETE: api/PersonSupplements/5
        /// <summary>
        /// Delete PersonSupplement, Based on parameter: id
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
        public async Task<IActionResult> DeletePersonSupplement(Guid id)
        {
            var personSupplement = await _context.PersonSupplements.FindAsync(id);
            if (personSupplement == null)
            {
                return NotFound();
            }

            _context.PersonSupplements.Remove(personSupplement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonSupplementExists(Guid id)
        {
            return _context.PersonSupplements.Any(e => e.Id == id);
        }
    }
}
*/
