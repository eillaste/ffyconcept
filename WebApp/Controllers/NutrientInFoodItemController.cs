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
    public class NutrientInFoodItemController : Controller
    {
        private readonly IAppBLL _bll;

        public NutrientInFoodItemController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: NutrientInFoodItem
        public async Task<IActionResult> Index()
        {
            var res = await  _bll.NutrientInFoodItem.GetAllAsync(User.GetUserId()!.Value);
            await  _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: NutrientInFoodItem/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrientInFoodItem = await  _bll.NutrientInFoodItem.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrientInFoodItem == null)
            {
                return NotFound();
            }

            return View(nutrientInFoodItem);
        }

        // GET: NutrientInFoodItem/Create
        public async Task<IActionResult> Create()
        {
            var vm = new NutrientInFoodItemCreateEditViewModel();
            vm.FoodItemSelectList = new SelectList(await  _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title));
            vm.NutrientSelectList = new SelectList(await  _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title));
            return View(vm);
        }

        // POST: NutrientInFoodItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NutrientInFoodItemCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.NutrientInFoodItem.Add(vm.NutrientInFoodItem);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.NutrientInFoodItem.NutrientId);
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.NutrientInFoodItem.FoodItemId);
            return View(vm);
        }

        // GET: NutrientInFoodItem/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrientInFoodItem = await _bll.NutrientInFoodItem.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (nutrientInFoodItem == null)
            {
                return NotFound();
            }
            var vm = new NutrientInFoodItemCreateEditViewModel();
            vm.NutrientInFoodItem = nutrientInFoodItem;
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.NutrientInFoodItem.NutrientId);
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.NutrientInFoodItem.FoodItemId);
            return View(vm);
        }

        // POST: NutrientInFoodItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, NutrientInFoodItemCreateEditViewModel vm)
        {
            if (id != vm.NutrientInFoodItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _bll.NutrientInFoodItem.Update(vm.NutrientInFoodItem);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await NutrientInFoodItemExists(vm.NutrientInFoodItem.Id))
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
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.NutrientInFoodItem.NutrientId);
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.NutrientInFoodItem.FoodItemId);
            return View(vm);
        }

        // GET: NutrientInFoodItem/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrientInFoodItem = await _bll.NutrientInFoodItem.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrientInFoodItem == null)
            {
                return NotFound();
            }

            return View(nutrientInFoodItem);
        }

        // POST: NutrientInFoodItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var nutrientInFoodItem = await _bll.NutrientInFoodItem.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (nutrientInFoodItem == null)
            {
                return NotFound();
            }
            _bll.NutrientInFoodItem.Remove(nutrientInFoodItem);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<bool> NutrientInFoodItemExists(Guid id)
        {
            return await _bll.NutrientInFoodItem.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
