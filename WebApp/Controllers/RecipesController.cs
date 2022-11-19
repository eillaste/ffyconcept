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
using Microsoft.AspNetCore.Identity;
using PublicApi.DTO.v1;
using WebApp.ViewModels;
using ConsumedFoodItem = BLL.App.DTO.ConsumedFoodItem;
using ConsumedNutrient = BLL.App.DTO.ConsumedNutrient;
using Recipe = DAL.App.DTO.Recipe;

namespace WebApp.Controllers
{
    [Authorize(Roles = "customer,company,admin" )]
    public class RecipesController : Controller
    {
        private readonly IAppBLL _bll;

        public RecipesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        [Authorize(Roles = "customer,company,admin" )]
        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            IEnumerable<BLL.App.DTO.Recipe> res = null!;
            if (User.IsInRole("customer"))
            {
                res = await _bll.Recipes.GetAllAsync();
            } else if (User.IsInRole("company"))
            {
                res = await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value);
            }
            
            await _bll.SaveChangesAsync();
            return View(res);
        }
        
        public async Task<IActionResult> RegisterMeal(Guid id)
        {
            // create nutrient map
            Dictionary<Guid, double> foodItemMap = new Dictionary<Guid, double>();
            Dictionary<Guid, double> nutrientMap = new Dictionary<Guid, double>();

            
            // get ahold of appuser
            Console.WriteLine(id);
            var appuserId = User.GetUserId()!.Value;
            var recipe = await _bll.Recipes.FirstOrDefaultWithIncludesAsync(id, appuserId, true);
            Console.WriteLine(recipe);
            Console.WriteLine(recipe!.Description);
            Console.WriteLine(recipe!.Ingredients!.Count);
            Console.WriteLine("In " + recipe.Description + " there are " + recipe!.Ingredients.Count + " ingredients");
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!foodItemMap.ContainsKey(ingredient.FoodItemId))
                {
                    foodItemMap[ingredient.FoodItemId] = ingredient.Quantity;
                }
                else
                {
                    foodItemMap[ingredient.FoodItemId] = foodItemMap[ingredient.FoodItemId] + ingredient.Quantity;
                }
                
                
                Console.WriteLine(ingredient.Quantity + " " + ingredient.FoodItem!.StandardUnit!.Title +  " of " + ingredient.FoodItem!.Title + " which contains: ");
                foreach (var nutrientInFoodItem in ingredient.FoodItem!.NutrientInFoodItems!)
                {
                    if (!nutrientMap.ContainsKey(nutrientInFoodItem.NutrientId))
                    {
                        nutrientMap[nutrientInFoodItem.NutrientId] = nutrientInFoodItem.Quantity * ingredient.Quantity;
                    }
                    else
                    {
                        nutrientMap[nutrientInFoodItem.NutrientId] = nutrientMap[nutrientInFoodItem.NutrientId] + nutrientInFoodItem.Quantity * ingredient.Quantity;
                    }
                    Console.WriteLine(nutrientInFoodItem.Quantity * ingredient.Quantity + " " + nutrientInFoodItem.Nutrient!.StandardUnit!.Title + " of " + nutrientInFoodItem.Nutrient!.Title);
                }
                Console.WriteLine("--------");
            }
            Console.WriteLine("Meal registered");
            Console.WriteLine(foodItemMap.Count);
            foodItemMap.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            Console.WriteLine(nutrientMap.Count);
            nutrientMap.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

            foreach (var keyValuePair in foodItemMap)
            {
                _bll.ConsumedFoodItems.Add(new ConsumedFoodItem()
                {
                    AppUserId = User.GetUserId()!.Value,
                    FoodItemId = keyValuePair.Key,
                    Quantity = keyValuePair.Value,
                    Date = DateTime.Now
                });
            }
            await _bll.SaveChangesAsync();
            foreach (var keyValuePair in nutrientMap)
            {
                _bll.ConsumedNutrients.Add(new ConsumedNutrient()
                {
                    AppUserId = User.GetUserId()!.Value,
                    NutrientId = keyValuePair.Key,
                    Quantity = keyValuePair.Value,
                    Date = DateTime.Now
                });
            }
            
            await _bll.SaveChangesAsync();
            /*IEnumerable<BLL.App.DTO.Recipe> res = null!;
            if (User.IsInRole("customer"))
            {
                res = await _bll.Recipes.GetAllAsync();
            } else if (User.IsInRole("company"))
            {
                res = await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value);
            }
            await _bll.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }
        
        [Authorize(Roles = "customer,company,admin" )]
        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BLL.App.DTO.Recipe recipe = null!;
            if (User.IsInRole("customer"))
            {
                recipe = (await _bll.Recipes.FirstOrDefaultAsync(id.Value))!;
            } else if (User.IsInRole("company"))
            {
                recipe = (await _bll.Recipes.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value))!;
            }
            
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }
        
        [Authorize(Roles = "company" )]
        // GET: Recipes/Create
        public IActionResult Create()
        {
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            var vm = new RecipeCreateEditViewModel();
            return View(vm);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "company" )]
        public async Task<IActionResult> Create(RecipeCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Recipe.AppUserId = User.GetUserId()!.Value;
                _bll.Recipes.Add(vm.Recipe);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", recipe.AppUserId);
            return View(vm);
        }

        // GET: Recipes/Edit/5
        [Authorize(Roles = "company" )]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _bll.Recipes.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (recipe == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", recipe.AppUserId);
            var vm = new RecipeCreateEditViewModel();
            vm.Recipe = recipe;
            return View(vm);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "company" )]
        public async Task<IActionResult> Edit(Guid id,RecipeCreateEditViewModel vm)
        {
            if (id != vm.Recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Recipe.AppUserId = User.GetUserId()!.Value;
                    _bll.Recipes.Update(vm.Recipe);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await RecipeExists(vm.Recipe.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", recipe.AppUserId);
            return View(vm);
        }

        // GET: Recipes/Delete/5
        [Authorize(Roles = "company" )]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _bll.Recipes.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "company" )]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var recipe = await _bll.Recipes.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (recipe == null)
            {
                return NotFound();
            }
            _bll.Recipes.Remove(recipe);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<bool> RecipeExists(Guid id)
        {
            return await _bll.Recipes.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
