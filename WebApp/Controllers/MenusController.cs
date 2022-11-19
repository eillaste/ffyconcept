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
    public class MenusController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public MenusController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Menus.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _uow.Menus.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public async Task<IActionResult> Create()
        {
            var vm = new MenuCreateEditViewModel();
            vm.RestaurantSelectList = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), nameof(Restaurant.Id),nameof(Restaurant.Description));
            return View(vm);
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Menu.AppUserId = User.GetUserId()!.Value;
                _uow.Menus.Add(vm.Menu);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", menu.AppUserId);
            vm.RestaurantSelectList = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), nameof(Restaurant.Id),nameof(Restaurant.Description), vm.Menu.RestaurantId);
            return View(vm);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _uow.Menus.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (menu == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", menu.AppUserId);
            var vm = new MenuCreateEditViewModel();
            vm.Menu = menu;
            vm.RestaurantSelectList = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), nameof(Restaurant.Id),nameof(Restaurant.Description), vm.Menu.RestaurantId);
            return View(vm);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MenuCreateEditViewModel vm)
        {
            if (id != vm.Menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Menu.AppUserId = User.GetUserId()!.Value;
                    _uow.Menus.Update(vm.Menu);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await MenuExists(vm.Menu.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", menu.AppUserId);
            vm.RestaurantSelectList = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), nameof(Restaurant.Id),nameof(Restaurant.Description), vm.Menu.RestaurantId);
            return View(vm);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _uow.Menus.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Menus.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MenuExists(Guid id)
        {
            return await _uow.Menus.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
