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

    public class PersonAllergensController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonAllergenMapper _personAllergenMapper;

        public PersonAllergensController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personAllergenMapper = new PersonAllergenMapper(Mapper);
        }

        // GET: api/PersonAllergens
        /// <summary>
        /// Get all PersonAllergens
        /// </summary>
        /// <returns>List of PersonAllergens</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonAllergen>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PersonAllergen>>> GetPersonAllergens()
        {
            return await _context.PersonAllergens.ToListAsync();
        }

        // GET: api/PersonAllergens/5
        /// <summary>
        /// Get one PersonAllergen, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>PersonAllergen entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonAllergen), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonAllergen>> GetPersonAllergen(Guid id)
        {
            var personAllergen = await _context.PersonAllergens.FindAsync(id);

            if (personAllergen == null)
            {
                return NotFound();
            }

            return personAllergen;
        }

        // PUT: api/PersonAllergens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one PersonAllergen, Based on parameters: Id, PersonAllergen
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personAllergen"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonAllergen), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonAllergen(Guid id, PersonAllergen personAllergen)
        {
            if (id != personAllergen.Id)
            {
                return BadRequest();
            }

            _context.Entry(personAllergen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAllergenExists(id))
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

        // POST: api/PersonAllergens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add PersonAllergen, Based on request body: PersonAllergen
        /// </summary>
        /// <param name="personAllergen"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonAllergen), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonAllergen>> PostPersonAllergen(PersonAllergen personAllergen)
        {
            _context.PersonAllergens.Add(personAllergen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonAllergen", new { id = personAllergen.Id }, personAllergen);
        }

        // DELETE: api/PersonAllergens/5
        /// <summary>
        /// Delete PersonAllergen, Based on parameter: id
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
        public async Task<IActionResult> DeletePersonAllergen(Guid id)
        {
            var personAllergen = await _context.PersonAllergens.FindAsync(id);
            if (personAllergen == null)
            {
                return NotFound();
            }

            _context.PersonAllergens.Remove(personAllergen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonAllergenExists(Guid id)
        {
            return _context.PersonAllergens.Any(e => e.Id == id);
        }
    }
}
*/
