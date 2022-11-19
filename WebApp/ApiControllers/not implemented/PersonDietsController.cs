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
    public class PersonDietsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonDietMapper _personDietMapper;

        public PersonDietsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personDietMapper = new PersonDietMapper(Mapper);
        }

        // GET: api/PersonDiets
        /// <summary>
        /// Get all PersonDiets
        /// </summary>
        /// <returns>List of PersonDiets</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonDiet>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PersonDiet>>> GetPersonDiets()
        {
            return await _context.PersonDiets.ToListAsync();
        }

        // GET: api/PersonDiets/5
        /// <summary>
        /// Get one PersonDiet, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>PersonDiet entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonDiet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonDiet>> GetPersonDiet(Guid id)
        {
            var personDiet = await _context.PersonDiets.FindAsync(id);

            if (personDiet == null)
            {
                return NotFound();
            }

            return personDiet;
        }

        // PUT: api/PersonDiets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one PersonDiet, Based on parameters: Id, PersonDiet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personDiet"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonDiet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonDiet(Guid id, PersonDiet personDiet)
        {
            if (id != personDiet.Id)
            {
                return BadRequest();
            }

            _context.Entry(personDiet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDietExists(id))
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

        // POST: api/PersonDiets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add PersonDiet, Based on request body: PersonDiet
        /// </summary>
        /// <param name="personDiet"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonDiet), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonDiet>> PostPersonDiet(PersonDiet personDiet)
        {
            _context.PersonDiets.Add(personDiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonDiet", new { id = personDiet.Id }, personDiet);
        }

        // DELETE: api/PersonDiets/5
        /// <summary>
        /// Delete PersonDiet, Based on parameter: id
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
        public async Task<IActionResult> DeletePersonDiet(Guid id)
        {
            var personDiet = await _context.PersonDiets.FindAsync(id);
            if (personDiet == null)
            {
                return NotFound();
            }

            _context.PersonDiets.Remove(personDiet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonDietExists(Guid id)
        {
            return _context.PersonDiets.Any(e => e.Id == id);
        }
    }
}
*/
