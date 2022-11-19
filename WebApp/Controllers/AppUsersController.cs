using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.DTO;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
using Domain.App.Identity;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;
using PublicApi.DTO.v1.Mappers;
using WebApp.ViewModels;


namespace WebApp.Controllers
{
    [Authorize(Roles = "admin,customer,company")]
    public class AppUsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonRecommendedDietaryIntakeMapper _personRecommendedDietaryIntakeMapper;
        public AppUsersController(AppDbContext context,IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personRecommendedDietaryIntakeMapper = new PersonRecommendedDietaryIntakeMapper(Mapper);
        }
//
        // GET: AppUsers
        public async Task<IActionResult> Index()
        {
            var res = await _bll.AppUsers.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
            //return View(await _context.AppUsers.ToListAsync());
        }
        


        /*
        // GET: AppUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultWithIncludesAsync(id.Value,User.GetUserId()!.Value);
            /*var appUser = await _context.AppUsers
                .FirstOrDefaultAsync(m => m.Id == id);#1#
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: AppUsers/Create
        public IActionResult Create()
        {

            
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                appUser.Id = Guid.NewGuid();
                _context.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }
        */

        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _bll.AppUsers.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            //var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            
            List<EGender?> list = new List<EGender?>();
            list.Add(EGender.Female);
            list.Add(EGender.Male);
            IEnumerable<EGender?> en = list;
            
            var vm = new AppUserCreateEditViewModel();
            vm.AppUser = appUser;
            Console.WriteLine("EDITING");
            //ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Console.WriteLine(vm.AppUser.Id);
            vm.GenderSelectList = new SelectList(en);
            //ViewData["Genders"] = new SelectList(en);
            
            return View(vm);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AppUserCreateEditViewModel vm)
        {
            vm.AppUser.Id = User.GetUserId()!.Value;
           Console.WriteLine("in post edit");
            if (id != vm.AppUser.Id)
            {
                Console.WriteLine(id);
                Console.WriteLine(vm.AppUser.Gender);
                Console.WriteLine("no appuserid!");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("VALID");
         
                try
                {
                    /*vm.AppUser.Id = User.GetUserId()!.Value;
                    Console.WriteLine(1);
                    _bll.AppUsers.Update(vm.AppUser);
                    Console.WriteLine(2);
                    await _bll.SaveChangesAsync();
                    Console.WriteLine(3);*/
                    var res = _context.AppUsers.FirstOrDefault(m => m.Id == User.GetUserId()!.Value);
                    
                    res!.Born = vm.AppUser.Born;
                    res!.Gender = vm.AppUser.Gender;
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
                    recommendedDietaryIntakes = recommendedDietaryIntakes.Where(r => r.AgeGroupId == matchingAgeGroupId.Id && r.Gender == vm.AppUser.Gender);
                    Console.WriteLine("HOW MANY MATCHING DIETARY INTAKES?");
                    Console.WriteLine(recommendedDietaryIntakes.ToList().Count);
                    
                    //this needs to be put to bll also
                    ////await _bll.PersonRecommendedDietaryIntake.RemoveAll(User.GetUserId().Value, true);
                    /*var stuffToRemove = await _context.PersonRecommendedDietaryIntake.Where(c=>c.AppUserId==User.GetUserId()!.Value).ToListAsync();
                    _context.PersonRecommendedDietaryIntake.RemoveRange(stuffToRemove);*/
                    
                    //alt implementation (bll calls bll?)
                    await _bll.PersonRecommendedDietaryIntake.RemoveOldRecommendationsAsync(User.GetUserId()!.Value, true);
                    //Console.WriteLine("done removing olds");
                    await _bll.SaveChangesAsync();
                    //Console.WriteLine("done saving changes");
                    
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
                        var blla = PersonRecommendedDietaryIntakeMapper.MapToBll(a);
                        _bll.PersonRecommendedDietaryIntake.Add(blla);
                        await _bll.SaveChangesAsync();
                    }

                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await AppUserExists(vm.AppUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            
            
            List<EGender?> list = new List<EGender?>();
            list.Add(EGender.Female);
            list.Add(EGender.Male);
            IEnumerable<EGender?> en = list;
            
            //var vm = new AppUserCreateEditViewModel();
            Console.WriteLine("EDITING");
            //ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewData["Genders"] = new SelectList(en);
            
            return View(vm);
        }

        /*
        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }*/

        /*
        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private async Task<bool> AppUserExists(Guid id)
        {
            return await _bll.AppUsers.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
