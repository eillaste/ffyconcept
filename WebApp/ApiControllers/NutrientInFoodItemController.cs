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
    public class NutrientInFoodItemController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private NutrientInFoodItemMapper _nutrientInFoodItemMapper;

        public NutrientInFoodItemController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _nutrientInFoodItemMapper = new NutrientInFoodItemMapper(Mapper);
        }

        // GET: api/NutrientInFoodItem
        /// <summary>
        /// Get all NutrientInFoodItem
        /// </summary>
        /// <returns>List of NutrientInFoodItem</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.NutrientInFoodItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.NutrientInFoodItem>>> GetNutrientInFoodItem()
        {
            return Ok((await _bll.NutrientInFoodItem.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.NutrientInFoodItem, PublicApi.DTO.v1.NutrientInFoodItem>(s)
                /*new PublicApi.DTO.v1.NutrientInFoodItem()
            {
                Id = s.Id,
                NutrientId = s.NutrientId,
                FoodItemId = s.FoodItemId,
                Quantity = s.Quantity 
            }*/));
        }

        // GET: api/NutrientInFoodItem/5
        /// <summary>
        /// Get one NutrientInFoodItem, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>NutrientInFoodItem entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.NutrientInFoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.NutrientInFoodItem>> GetNutrientInFoodItem(Guid id)
        {
            var nutrientInFoodItem = await _bll.NutrientInFoodItem.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (nutrientInFoodItem == null)
            {
                return NotFound();
            }
            
            /*var res = new PublicApi.DTO.v1.NutrientInFoodItem()
            {
                Id = nutrientInFoodItem.Id,
                NutrientId = nutrientInFoodItem.NutrientId,
                FoodItemId = nutrientInFoodItem.FoodItemId,
                Quantity = nutrientInFoodItem.Quantity 
            };*/

            return Mapper.Map<BLL.App.DTO.NutrientInFoodItem, PublicApi.DTO.v1.NutrientInFoodItem>(nutrientInFoodItem);
        }

        // PUT: api/NutrientInFoodItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one NutrientInFoodItem, Based on parameters: Id, NutrientInFoodItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nutrientInFoodItem"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.NutrientInFoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutNutrientInFoodItem(Guid id, PublicApi.DTO.v1.NutrientInFoodItemAddPut nutrientInFoodItem)
        {
            if (id != nutrientInFoodItem.Id)
            {
                return BadRequest();
            }

            
            var bllNutrientInFoodItem = NutrientInFoodItemMapper.MapToBll(nutrientInFoodItem);

            _bll.NutrientInFoodItem.Update(bllNutrientInFoodItem);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/NutrientInFoodItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add NutrientInFoodItem, Based on request body: NutrientInFoodItem
        /// </summary>
        /// <param name="nutrientInFoodItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.NutrientInFoodItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.NutrientInFoodItem>> PostNutrientInFoodItem(PublicApi.DTO.v1.NutrientInFoodItemAddPut nutrientInFoodItem)
        {
            var bllNutrientInFoodItem = NutrientInFoodItemMapper.MapToBll(nutrientInFoodItem);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedNutrientInFoodItem = _bll.NutrientInFoodItem.Add(bllNutrientInFoodItem);
            await _bll.SaveChangesAsync();
            var returnNutrientInFoodItem = _nutrientInFoodItemMapper.Map(addedNutrientInFoodItem);
            
            // this is sketchy af
            //returnNutrientInFoodItem!.Range = bllNutrientInFoodItem.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetNutrientInFoodItem", new {id = returnNutrientInFoodItem!.Id}, returnNutrientInFoodItem);
        }

        // DELETE: api/NutrientInFoodItem/5
        /// <summary>
        /// Delete NutrientInFoodItem, Based on parameter: id
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
        public async Task<IActionResult> DeleteNutrientInFoodItem(Guid id)
        {
            var nutrientInFoodItem = await _bll.NutrientInFoodItem.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (nutrientInFoodItem == null)
            {
                return NotFound();
            }

            _bll.NutrientInFoodItem.Remove(nutrientInFoodItem);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> NutrientInFoodItemExists(Guid id)
        {
            return await _bll.NutrientInFoodItem.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
