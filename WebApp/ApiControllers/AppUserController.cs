using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.DTO.Identity;
using BLL.App.Mappers;
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
using PublicApi.DTO.v1;
using ConsumedFoodItemMapper = PublicApi.DTO.v1.Mappers.ConsumedFoodItemMapper;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AppUserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        //private ConsumedFoodItemMapper _consumedFoodItemMapper;
        private PersonRecommendedDietaryIntakeMapper _personRecommendedDietaryIntakeMapper;
        
        
        public AppUserController(AppDbContext context,IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _bll = bll;
            _uow = uow;
           // Mapper = mapper;
            //_consumedFoodItemMapper = new ConsumedFoodItemMapper(Mapper);
            Mapper = mapper;
            _personRecommendedDietaryIntakeMapper = new PersonRecommendedDietaryIntakeMapper(Mapper);
        }

        /*// GET: api/ConsumedFoodItems
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
                new PublicApi.DTO.v1.ConsumedFoodItem()
                {
                    Id = s.Id,
                    FoodItemId = s.FoodItemId,
                    FoodItem = s.FoodItemName!,
                    Date = s.Date,
                    Quantity = s.Quantity
                }));
        }*/

        // GET: api/AppUser/5
        /// <summary>
        /// Get one AppUser, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>AppUser entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AppUser), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Domain.App.Identity.AppUser? GetAppUser(Guid id)
        {
            //var consumedFoodItem = await _context.ConsumedFoodItems.FindAsync(id);
            var appUser =  _context.AppUsers.FirstOrDefault(m => m.Id == User.GetUserId()!.Value);
            if (appUser == null)
            {
               // return NotFound();
            }

            Console.WriteLine("im here");
            /*var res = new PublicApi.DTO.v1.ConsumedFoodItem()
            {
                /*Id = consumedFoodItem.Id,
                FoodItemId = consumedFoodItem.FoodItemId,
                FoodItem = consumedFoodItem.FoodItem!.Title,
                Date = consumedFoodItem.Date,
                Quantity = consumedFoodItem.Quantity#1#
            };*/

            return appUser!;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one AppUser, Based on parameters: id, {gender, born}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AppUser), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutConsumedFoodItem(Guid id, AppUserDTO appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }
                                
                    var res = _context.AppUsers.FirstOrDefault(m => m.Id == User.GetUserId()!.Value);
                    res!.Born = appUser.Born;
                    res!.Gender = appUser.Gender;
                    Console.WriteLine(appUser);
                    Console.WriteLine(res.Born);
                    Console.WriteLine(res.Gender);
                    
                    
                    await _context.SaveChangesAsync();
                    
                    
                    // comparing datetime to now, birthdate 1991 returns -1 since it is earlier.
                    // but this can be used to determine consumed fooditem date (0)
                    // Console.WriteLine(res.Born.Date.CompareTo(DateTime.Today)); -1 is not today, 0 is today, 1 is tomorrow
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    TimeSpan span = DateTime.Now - res.Born;
                    int years = (zeroTime + span).Year - 1;
                    Console.WriteLine(years);
                    var agegroups = await _bll.AgeGroups.GetAllAsync();
                    var matchingAgeGroupId = agegroups.Where(a => a.LowerBound <= years && a.UpperBound >= years).First();
                    Console.WriteLine(matchingAgeGroupId.Id);
                    //var nutrients = await _bll.Nutrients.GetAllAsync();
                    
                    var recommendedDietaryIntakes = await _bll.RecommendedDietaryIntake.GetAllAsync();
                    Console.WriteLine(recommendedDietaryIntakes.ToList().Count);
                    recommendedDietaryIntakes = recommendedDietaryIntakes.Where(r => r.AgeGroupId == matchingAgeGroupId.Id && r.Gender == res.Gender);
                    Console.WriteLine("HOW MANY MATCHING DIETARY INTAKES?");
                    Console.WriteLine(recommendedDietaryIntakes.ToList().Count);

                    //alt implementation (bll calls bll?)
                    await _bll.PersonRecommendedDietaryIntake.RemoveOldRecommendationsAsync(User.GetUserId()!.Value, true);
                    await _bll.SaveChangesAsync();

                    
                    foreach (var recommendedDietaryIntake in recommendedDietaryIntakes)
                    {
                        Console.WriteLine("adding recommended dietary intake"); 
                        var a = new PublicApi.DTO.v1.PersonRecommendedDietaryIntakeAddPut()
                        {
                            AppUserId = User.GetUserId()!.Value,
                            RecommendedDietaryIntakeId = recommendedDietaryIntake.Id,
                            NutrientId = recommendedDietaryIntake.NutrientId,
                            HealthSpecificationNutrientId = new Guid("03E66031-17F5-4870-6786-08D91C70E5E8"),
                            Start = DateTime.Now,
                            End = DateTime.MaxValue,
                        };
                        
                        var blla = PublicApi.DTO.v1.Mappers.PersonRecommendedDietaryIntakeMapper.MapToBll(a);
                        _bll.PersonRecommendedDietaryIntake.Add(blla);
                        await _bll.SaveChangesAsync();
                    }

                    
            
            return NoContent();
        }

        /*// POST: api/ConsumedFoodItems
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
            return CreatedAtAction("GetConsumedFoodItem", new {id = consumedFoodItem!.Id}, consumedFoodItem);#1#
            
            var bllConsumedFoodItem = ConsumedFoodItemMapper.MapToBll(consumedFoodItem);
            bllConsumedFoodItem.AppUserId = User.GetUserId()!.Value;
            var addedConsumedFoodItem = _bll.ConsumedFoodItems.Add(bllConsumedFoodItem);
            await _bll.SaveChangesAsync();
            var returnConsumedFoodItem = _consumedFoodItemMapper.Map(addedConsumedFoodItem);
            
            // this is sketchy af
            returnConsumedFoodItem!.FoodItem = bllConsumedFoodItem.FoodItemName!;
            return CreatedAtAction("GetConsumedFoodItem", new {id = returnConsumedFoodItem!.Id}, returnConsumedFoodItem);
        }*/

        /*// DELETE: api/ConsumedFoodItems/5
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
        }*/

        private async Task<bool> AgeGroupExists(Guid id)
        {
            return await _bll.ConsumedFoodItems.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
