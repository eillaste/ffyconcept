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

//using DTO.App;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="admin,company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FoodItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private FoodItemMapper _foodItemMapper;

        public FoodItemsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _foodItemMapper = new FoodItemMapper(Mapper);
        }

        // GET: api/FoodItems
        /// <summary>
        /// Get all FoodItems
        /// </summary>
        /// <returns>List of FoodItems</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.FoodItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.FoodItem>>> GetFoodItems()
        {
            return Ok((await _bll.FoodItems.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.FoodItem, PublicApi.DTO.v1.FoodItem>(s)
));
            
            /*var res = await _uow.FoodItems.GetAllWithCountsAsync();
            return Ok(res);*/
        }

        // GET: api/FoodItems/5
        /// <summary>
        /// Get one FoodItem, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>FoodItem entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.FoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.FoodItem>> GetFoodItem(Guid id)
        {
            var foodItem = await  _bll.FoodItems.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (foodItem == null)
            {
                return NotFound();
            }

            /*var res = new PublicApi.DTO.v1.FoodItem()
            {
                Id = foodItem.Id,
                Title = foodItem.Title,
                StandardUnitId = foodItem.StandardUnitId,
                CategoryId = foodItem.CategoryId
            };*/
            
            return Mapper.Map<BLL.App.DTO.FoodItem, PublicApi.DTO.v1.FoodItem>(foodItem);
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one FoodItem, Based on parameters: Id, FoodItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="foodItem"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.FoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutFoodItem(Guid id, PublicApi.DTO.v1.FoodItemAddPut foodItem)
        {
            if (id != foodItem.Id)
            {
                return BadRequest();
            }
            
            var bllFoodItem = FoodItemMapper.MapToBll(foodItem);

            _bll.FoodItems.Update(bllFoodItem);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add FoodItem, Based on request body: FoodItem
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.FoodItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.FoodItem>> PostFoodItem(PublicApi.DTO.v1.FoodItemAddPut foodItem)
        {
            var bllFoodItem = FoodItemMapper.MapToBll(foodItem);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedFoodItem = _bll.FoodItems.Add(bllFoodItem);
            await _bll.SaveChangesAsync();
            var returnFoodItem = _foodItemMapper.Map(addedFoodItem);
            
            // this is sketchy af
            //returnFoodItem!.Range = bllFoodItem.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetFoodItem", new {id = returnFoodItem!.Id}, returnFoodItem);
        }

        // DELETE: api/FoodItems/5
        /// <summary>
        /// Delete FoodItem, Based on parameter: id
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
        public async Task<IActionResult> DeleteFoodItem(Guid id)
        {
            var foodItem = await _bll.FoodItems.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (foodItem == null)
            {
                return NotFound();
            }

            _bll.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> FoodItemExists(Guid id)
        {
            return await _bll.FoodItems.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
