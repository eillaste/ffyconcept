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
    public class StockController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public StockController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Stock
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Stock.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Stock/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _uow.Stock.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stock/Create
        public async Task<IActionResult> Create()
        {
            var vm = new StockCreateEditViewModel();
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title));
            return View(vm);
        }

        // POST: Stock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Stock.AppUserId = User.GetUserId()!.Value;
                _uow.Stock.Add(vm.Stock);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.Stock.FoodItemId);
            return View(vm);
        }

        // GET: Stock/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _uow.Stock.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (stock == null)
            {
                return NotFound();
            }
            var vm = new StockCreateEditViewModel();
            vm.Stock = stock;
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.Stock.FoodItemId);
            return View(vm);
        }

        // POST: Stock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StockCreateEditViewModel vm)
        {
            if (id != vm.Stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Stock.AppUserId = User.GetUserId()!.Value;
                    _uow.Stock.Update(vm.Stock);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await StockExists(vm.Stock.Id))
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
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.Stock.FoodItemId);
            return View(vm);
        }

        // GET: Stock/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _uow.Stock.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Stock.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private  async Task<bool> StockExists(Guid id)
        {
            return await _uow.Stock.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
