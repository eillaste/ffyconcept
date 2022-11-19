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
    [Authorize(Roles = "admin" )]
    public class FoodItemsController : Controller
    {
        private readonly IAppBLL _bll;

        public FoodItemsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: FoodItems
        public async Task<IActionResult> Index()
        {
            var res = await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: FoodItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _bll.FoodItems.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // GET: FoodItems/Create
        public async Task<IActionResult> Create()
        {
            var vm = new FoodItemCreateEditViewModel();
            vm.CategorySelectList = new SelectList(await _bll.Categories.GetAllAsync(User.GetUserId()!.Value), nameof(Category.Id),nameof(Category.Title));
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title));
            return View(vm);
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodItemCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.FoodItems.Add(vm.FoodItem);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.CategorySelectList = new SelectList(await _bll.Categories.GetAllAsync(User.GetUserId()!.Value), nameof(Category.Id),nameof(Category.Title), vm.FoodItem.CategoryId);
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.FoodItem.StandardUnitId);
            return View(vm);
        }

        // GET: FoodItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _bll.FoodItems.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (foodItem == null)
            {
                return NotFound();
            }
            var vm = new FoodItemCreateEditViewModel();
            vm.FoodItem = foodItem;
            vm.CategorySelectList = new SelectList(await _bll.Categories.GetAllAsync(User.GetUserId()!.Value), nameof(Category.Id),nameof(Category.Title), vm.FoodItem.CategoryId);
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.FoodItem.StandardUnitId);
            return View(vm);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,FoodItemCreateEditViewModel vm)
        {
            if (id != vm.FoodItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.FoodItems.Update(vm.FoodItem);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await FoodItemExists(vm.FoodItem.Id))
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
            vm.CategorySelectList = new SelectList(await _bll.Categories.GetAllAsync(User.GetUserId()!.Value), nameof(Category.Id),nameof(Category.Title), vm.FoodItem.CategoryId);
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.FoodItem.StandardUnitId);
            return View(vm);
        }

        // GET: FoodItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _bll.FoodItems.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var foodItem = await _bll.FoodItems.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (foodItem == null)
            {
                return NotFound();
            }
            _bll.FoodItems.Remove(foodItem);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<bool> FoodItemExists(Guid id)
        {
            return await _bll.FoodItems.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
