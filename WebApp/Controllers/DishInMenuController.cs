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
    [Authorize(Roles = "company,admin" )]
    public class DishInMenuController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public DishInMenuController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: DishInMenu
        public async Task<IActionResult> Index()
        {
            var res = await _uow.DishInMenu.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: DishInMenu/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInMenu = await _uow.DishInMenu.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (dishInMenu == null)
            {
                return NotFound();
            }

            return View(dishInMenu);
        }

        // GET: DishInMenu/Create
        public async Task<IActionResult>  Create()
        {
            var vm = new DishInMenuCreateEditViewModel();
            vm.MenuSelectList = new SelectList(await _uow.Menus.GetAllAsync(User.GetUserId()!.Value), nameof(Menu.Id),nameof(Menu.Id));
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description));
            return View(vm);
        }

        // POST: DishInMenu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DishInMenuCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.DishInMenu.AppUserId = User.GetUserId()!.Value;
                _uow.DishInMenu.Add(vm.DishInMenu);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.MenuSelectList = new SelectList(await _uow.Menus.GetAllAsync(User.GetUserId()!.Value), nameof(Menu.Id),nameof(Menu.Id), vm.DishInMenu.MenuId);
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.DishInMenu.RecipeId);
            return View(vm);
        }

        // GET: DishInMenu/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInMenu = await _uow.DishInMenu.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (dishInMenu == null)
            {
                return NotFound();
            }

            var vm = new DishInMenuCreateEditViewModel();
            vm.DishInMenu = dishInMenu;
            vm.MenuSelectList = new SelectList(await _uow.Menus.GetAllAsync(User.GetUserId()!.Value), nameof(Menu.Id),nameof(Menu.Id), vm.DishInMenu.MenuId);
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.DishInMenu.RecipeId);
            return View(vm);
        }

        // POST: DishInMenu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DishInMenuCreateEditViewModel vm)
        {
            if (id != vm.DishInMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.DishInMenu.AppUserId = User.GetUserId()!.Value;
                    _uow.DishInMenu.Update(vm.DishInMenu);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await DishInMenuExists(vm.DishInMenu.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", dishInMenu.AppUserId);
            vm.MenuSelectList = new SelectList(await _uow.Menus.GetAllAsync(User.GetUserId()!.Value), nameof(Menu.Id),nameof(Menu.Id), vm.DishInMenu.MenuId);
            vm.RecipeSelectList = new SelectList(await _uow.Recipes.GetAllAsync(User.GetUserId()!.Value), nameof(Recipe.Id),nameof(Recipe.Description), vm.DishInMenu.RecipeId);
            return View(vm);
        }

        // GET: DishInMenu/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInMenu = await _uow.DishInMenu.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (dishInMenu == null)
            {
                return NotFound();
            }

            return View(dishInMenu);
        }

        // POST: DishInMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.DishInMenu.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DishInMenuExists(Guid id)
        {
            return await _uow.DishInMenu.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
