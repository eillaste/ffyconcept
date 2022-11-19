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
    [Authorize(Roles = "customer,company,admin" )]
    public class RecipeTagsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public RecipeTagsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: RecipeTags
        public async Task<IActionResult> Index()
        {
            var res = await _uow.RecipeTags.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: RecipeTags/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeTag = await _uow.RecipeTags.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (recipeTag == null)
            {
                return NotFound();
            }

            return View(recipeTag);
        }

        // GET: RecipeTags/Create
        public async Task<IActionResult> Create()
        {
            var vm = new RecipeTagCreateEditViewModel();
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description));
            vm.TagSelectList = new SelectList(await _uow.Tags.GetAllAsync(User.GetUserId()!.Value), nameof(Tag.Id),nameof(Tag.Name));
            return View(vm);
        }

        // POST: RecipeTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeTagCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.RecipeTag.AppUserId = User.GetUserId()!.Value;
                _uow.RecipeTags.Add(vm.RecipeTag);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.RecipeTag.RecipeId);
            vm.TagSelectList = new SelectList(await _uow.Tags.GetAllAsync(User.GetUserId()!.Value), nameof(Tag.Id),nameof(Tag.Name), vm.RecipeTag.TagId);
            return View(vm);
        }

        // GET: RecipeTags/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeTag = await _uow.RecipeTags.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (recipeTag == null)
            {
                return NotFound();
            }

            var vm = new RecipeTagCreateEditViewModel();
            vm.RecipeTag = recipeTag;
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.RecipeTag.RecipeId);
            vm.TagSelectList = new SelectList(await _uow.Tags.GetAllAsync(User.GetUserId()!.Value), nameof(Tag.Id),nameof(Tag.Name), vm.RecipeTag.TagId);
            return View(vm);
        }

        // POST: RecipeTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RecipeTagCreateEditViewModel vm)
        {
            if (id != vm.RecipeTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.RecipeTag.AppUserId = User.GetUserId()!.Value;
                    _uow.RecipeTags.Update(vm.RecipeTag);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await RecipeTagExists(vm.RecipeTag.Id))
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
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.RecipeTag.RecipeId);
            vm.TagSelectList = new SelectList(await _uow.Tags.GetAllAsync(User.GetUserId()!.Value), nameof(Tag.Id),nameof(Tag.Name), vm.RecipeTag.TagId);
            return View(vm);
        }

        // GET: RecipeTags/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeTag = await _uow.RecipeTags.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (recipeTag == null)
            {
                return NotFound();
            }

            return View(recipeTag);
        }

        // POST: RecipeTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.RecipeTags.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RecipeTagExists(Guid id)
        {
            return await _uow.RecipeTags.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
