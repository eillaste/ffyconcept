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
    public class DishInOrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private DishInOrderMapper _dishInOrderMapper;

        public DishInOrderController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _dishInOrderMapper = new DishInOrderMapper(Mapper);
        }

        // GET: api/DishInOrder
        /// <summary>
        /// Get all DishInOrder
        /// </summary>
        /// <returns>List of DishInOrder</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.DishInOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DishInOrder>>> GetDishInOrder()
        {
            return await _context.DishInOrder.ToListAsync();
        }

        // GET: api/DishInOrder/5
        /// <summary>
        /// Get one DishInOrder, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>DishInOrder entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DishInOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DishInOrder>> GetDishInOrder(Guid id)
        {
            var dishInOrder = await _context.DishInOrder.FindAsync(id);

            if (dishInOrder == null)
            {
                return NotFound();
            }

            return dishInOrder;
        }

        // PUT: api/DishInOrder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one DishInOrder, Based on parameters: Id, DishInOrder
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dishInOrder"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DishInOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutDishInOrder(Guid id, DishInOrder dishInOrder)
        {
            if (id != dishInOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishInOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishInOrderExists(id))
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

        // POST: api/DishInOrder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add DishInOrder, Based on request body: DishInOrder
        /// </summary>
        /// <param name="dishInOrder"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DishInOrder), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DishInOrder>> PostDishInOrder(DishInOrder dishInOrder)
        {
            _context.DishInOrder.Add(dishInOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishInOrder", new { id = dishInOrder.Id }, dishInOrder);
        }

        // DELETE: api/DishInOrder/5
        /// <summary>
        /// Delete DishInOrder, Based on parameter: id
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
        public async Task<IActionResult> DeleteDishInOrder(Guid id)
        {
            var dishInOrder = await _context.DishInOrder.FindAsync(id);
            if (dishInOrder == null)
            {
                return NotFound();
            }

            _context.DishInOrder.Remove(dishInOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishInOrderExists(Guid id)
        {
            return _context.DishInOrder.Any(e => e.Id == id);
        }
    }
}
*/
