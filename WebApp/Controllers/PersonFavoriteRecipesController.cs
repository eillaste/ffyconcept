using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Authorize(Roles = "customer,admin" )]
    public class PersonFavoriteRecipesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PersonFavoriteRecipesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PersonFavoriteRecipes
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PersonFavoriteRecipes.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PersonFavoriteRecipes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personFavoriteRecipe = await _uow.PersonFavoriteRecipes.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personFavoriteRecipe == null)
            {
                return NotFound();
            }

            return View(personFavoriteRecipe);
        }

        // GET: PersonFavoriteRecipes/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PersonFavoriteRecipeCreateEditViewModel();
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description));
            return View(vm);
        }

        // POST: PersonFavoriteRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonFavoriteRecipeCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PersonFavoriteRecipe.AppUserId = User.GetUserId()!.Value;
                _uow.PersonFavoriteRecipes.Add(vm.PersonFavoriteRecipe);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", personFavoriteRecipe.AppUserId);
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.PersonFavoriteRecipe.RecipeId);
            return View(vm);
        }

        // GET: PersonFavoriteRecipes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personFavoriteRecipe = await _uow.PersonFavoriteRecipes.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personFavoriteRecipe == null)
            {
                return NotFound();
            }
            var vm = new PersonFavoriteRecipeCreateEditViewModel();
            vm.PersonFavoriteRecipe = personFavoriteRecipe;
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.PersonFavoriteRecipe.RecipeId);
            return View(vm);
        }

        // POST: PersonFavoriteRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PersonFavoriteRecipeCreateEditViewModel vm)
        {
            if (id != vm.PersonFavoriteRecipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.PersonFavoriteRecipe.AppUserId = User.GetUserId()!.Value;
                    _uow.PersonFavoriteRecipes.Update(vm.PersonFavoriteRecipe);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await PersonFavoriteRecipeExists(vm.PersonFavoriteRecipe.Id))
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
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.PersonFavoriteRecipe.RecipeId);
            return View(vm);
        }

        // GET: PersonFavoriteRecipes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personFavoriteRecipe = await _uow.PersonFavoriteRecipes.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personFavoriteRecipe == null)
            {
                return NotFound();
            }

            return View(personFavoriteRecipe);
        }

        // POST: PersonFavoriteRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PersonFavoriteRecipes.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonFavoriteRecipeExists(Guid id)
        {
            return await _uow.PersonFavoriteRecipes.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
