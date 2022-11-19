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
    public class RestaurantsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public RestaurantsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _uow.Restaurants.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            var vm = new RestaurantCreateEditViewModel();
            return View(vm);
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RestaurantCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Restaurant.AppUserId = User.GetUserId()!.Value;
                _uow.Restaurants.Add(vm.Restaurant);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", restaurant.AppUserId);
            return View(vm);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _uow.Restaurants.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (restaurant == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", restaurant.AppUserId);
            var vm = new RestaurantCreateEditViewModel();
            vm.Restaurant = restaurant;
            return View(vm);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RestaurantCreateEditViewModel vm)
        {
            if (id != vm.Restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Restaurant.AppUserId = User.GetUserId()!.Value;
                    _uow.Restaurants.Update(vm.Restaurant);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await RestaurantExists(vm.Restaurant.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", restaurant.AppUserId);
            return View(vm);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _uow.Restaurants.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Restaurants.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RestaurantExists(Guid id)
        {
            return await _uow.Restaurants.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
