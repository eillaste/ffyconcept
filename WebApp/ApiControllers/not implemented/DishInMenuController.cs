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
    [Authorize(Roles="company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DishInMenuController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private DishInMenuMapper _dishInmenuMapper;

        public DishInMenuController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _dishInmenuMapper = new DishInMenuMapper(Mapper);
        }

        // GET: api/DishInMenu
        /// <summary>
        /// Get all DishInMenu
        /// </summary>
        /// <returns>List of DishInMenu</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.DishInMenu>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DishInMenu>>> GetDishInMenu()
        {
            return await _context.DishInMenu.ToListAsync();
        }

        // GET: api/DishInMenu/5
        /// <summary>
        /// Get one DishInMenu, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>DishInMenu entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DishInMenu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DishInMenu>> GetDishInMenu(Guid id)
        {
            var dishInMenu = await _context.DishInMenu.FindAsync(id);

            if (dishInMenu == null)
            {
                return NotFound();
            }

            return dishInMenu;
        }

        // PUT: api/DishInMenu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one DishInMenu, Based on parameters: Id, DishInMenu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dishInMenu"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DishInMenu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutDishInMenu(Guid id, DishInMenu dishInMenu)
        {
            if (id != dishInMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishInMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishInMenuExists(id))
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

        // POST: api/DishInMenu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add DishInMenu, Based on request body: DishInMenu
        /// </summary>
        /// <param name="dishInMenu"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.DishInMenu), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DishInMenu>> PostDishInMenu(DishInMenu dishInMenu)
        {
            _context.DishInMenu.Add(dishInMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishInMenu", new { id = dishInMenu.Id }, dishInMenu);
        }

        // DELETE: api/DishInMenu/5
        /// <summary>
        /// Delete DishInMenu, Based on parameter: id
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
        public async Task<IActionResult> DeleteDishInMenu(Guid id)
        {
            var dishInMenu = await _context.DishInMenu.FindAsync(id);
            if (dishInMenu == null)
            {
                return NotFound();
            }

            _context.DishInMenu.Remove(dishInMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishInMenuExists(Guid id)
        {
            return _context.DishInMenu.Any(e => e.Id == id);
        }
    }
}
*/
