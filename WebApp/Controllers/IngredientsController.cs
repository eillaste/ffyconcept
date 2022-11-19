using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "customer,company,admin" )]
    public class IngredientsController : Controller
    {
        private readonly IAppBLL _bll;

        public IngredientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var res = await _bll.Ingredients.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public async Task<IActionResult> Create()
        {
            var vm = new IngredientCreateEditViewModel();
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title));
            vm.RecipeSelectList = new SelectList(await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description));
            return View(vm);
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Ingredient.AppUserId = User.GetUserId()!.Value;
                _bll.Ingredients.Add(vm.Ingredient);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.Ingredient.FoodItemId);
            vm.RecipeSelectList = new SelectList(await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.Ingredient.RecipeId);
            return View(vm);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (ingredient == null)
            {
                return NotFound();
            }

            var vm = new IngredientCreateEditViewModel();
            vm.Ingredient = ingredient;
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.Ingredient.FoodItemId);
            vm.RecipeSelectList = new SelectList(await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.Ingredient.RecipeId);
            return View(vm);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,IngredientCreateEditViewModel vm)
        {
            if (id != vm.Ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Ingredient.AppUserId = User.GetUserId()!.Value;
                    _bll.Ingredients.Update(vm.Ingredient);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await IngredientExists(vm.Ingredient.Id))
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
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.Ingredient.FoodItemId);
            vm.RecipeSelectList = new SelectList(await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.Ingredient.RecipeId);
            return View(vm);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (ingredient == null)
            {
                return NotFound();
            }
            _bll.Ingredients.Remove(ingredient);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IngredientExists(Guid id)
        {
            return await _bll.Ingredients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
