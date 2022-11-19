using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.Services;
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
    [Authorize(Roles="customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ConsumedFoodItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private ConsumedFoodItemMapper _consumedFoodItemMapper;
        
        public ConsumedFoodItemsController(IAppUnitOfWork uow, AppDbContext context, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _bll = bll;
            _uow = uow;
            Mapper = mapper;
            _consumedFoodItemMapper = new ConsumedFoodItemMapper(Mapper);
        }

        // GET: api/ConsumedFoodItems
        /// <summary>
        /// Get all ConsumedFoodItems
        /// </summary>
        /// <returns>List of ConsumedFoodItems</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.ConsumedFoodItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.ConsumedFoodItem>>> GetConsumedFoodItems()
        {
            return Ok((await _bll.ConsumedFoodItems.GetAllFoodItemsWithInfo(User.GetUserId()!.Value)).Select(s =>
                Mapper.Map<BLL.App.DTO.ConsumedFoodItem, PublicApi.DTO.v1.ConsumedFoodItem>(s)
));
        }

        // GET: api/ConsumedFoodItems/5
        /// <summary>
        /// Get one ConsumedFoodItem, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>ConsumedFoodItem entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ConsumedFoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.ConsumedFoodItem>> GetConsumedFoodItem(Guid id)
        {
            //
            //var consumedFoodItem = await _context.ConsumedFoodItems.FindAsync(id);
            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultWithIncludesAsync(id, User.GetUserId()!.Value);
            if (consumedFoodItem == null)
            {
                return NotFound();
            }
            /*var res = new PublicApi.DTO.v1.ConsumedFoodItem()
            {
                Id = consumedFoodItem.Id,
                FoodItemId = consumedFoodItem.FoodItemId,
                FoodItem = consumedFoodItem.FoodItem!.Title!,
                Date = consumedFoodItem.Date,
                Quantity = consumedFoodItem.Quantity
            };*/

            return Mapper.Map<BLL.App.DTO.ConsumedFoodItem, PublicApi.DTO.v1.ConsumedFoodItem>(consumedFoodItem);
        }

        // PUT: api/ConsumedFoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one ConsumedFoodItem, Based on parameters: Id, ConsumedFoodItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consumedFoodItem"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ConsumedFoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutConsumedFoodItem(Guid id, PublicApi.DTO.v1.ConsumedFoodItemAddPut consumedFoodItem)
        {
            if (id != consumedFoodItem.Id)
            {
                return BadRequest();
            }

            var bllConsumedFoodItem = ConsumedFoodItemMapper.MapToBll(consumedFoodItem);
            bllConsumedFoodItem.AppUserId = User.GetUserId()!.Value;
            _bll.ConsumedFoodItems.Update(bllConsumedFoodItem);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ConsumedFoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add ConsumedFoodItem, Based on request body: ConsumedFoodItem
        /// </summary>
        /// <param name="consumedFoodItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ConsumedFoodItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.ConsumedFoodItemAddPut>> PostConsumedFoodItem(PublicApi.DTO.v1.ConsumedFoodItemAddPut consumedFoodItem)
        {
            //not 100% good
            /*consumedFoodItem.AppUserId = User.GetUserId()!.Value;
            var bllConsumedFoodItem = ConsumedFoodItemMapper.MapToBll(consumedFoodItem);
            var addedConsumedFoodItem = _bll.ConsumedFoodItems.Add(bllConsumedFoodItem);
            await _bll.SaveChangesAsync();
            consumedFoodItem.Id = addedConsumedFoodItem.Id;
            // this is sketchy af
            consumedFoodItem!.FoodItem = bllConsumedFoodItem.FoodItemName!;
            return CreatedAtAction("GetConsumedFoodItem", new {id = consumedFoodItem!.Id}, consumedFoodItem);*/
            
            var bllConsumedFoodItem = ConsumedFoodItemMapper.MapToBll(consumedFoodItem);
            bllConsumedFoodItem.AppUserId = User.GetUserId()!.Value;
            var addedConsumedFoodItem = _bll.ConsumedFoodItems.Add(bllConsumedFoodItem);
            await _bll.SaveChangesAsync();
            var returnConsumedFoodItem = _consumedFoodItemMapper.Map(addedConsumedFoodItem);
            
            // this is sketchy af
            returnConsumedFoodItem!.FoodItem = bllConsumedFoodItem.FoodItemName!;
            return CreatedAtAction("GetConsumedFoodItem", new {id = returnConsumedFoodItem!.Id}, returnConsumedFoodItem);
        }

        // DELETE: api/ConsumedFoodItems/5
        /// <summary>
        /// Delete ConsumedFoodItem, Based on parameter: id
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
            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (consumedFoodItem == null)
            {
                return NotFound();
            }
            _bll.ConsumedFoodItems.Remove(consumedFoodItem);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AgeGroupExists(Guid id)
        {
            return await _bll.ConsumedFoodItems.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
