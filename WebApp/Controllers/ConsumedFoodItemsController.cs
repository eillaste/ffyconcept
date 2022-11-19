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
    [Authorize(Roles = "customer,admin" )]
    public class ConsumedFoodItemsController : Controller
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;

        public ConsumedFoodItemsController(IAppUnitOfWork uow, IAppBLL bll)
        {
            _uow = uow;
            _bll = bll;
        }

        // GET: ConsumedFoodItems
        public async Task<IActionResult> Index()
        {
            var res = await _bll.ConsumedFoodItems.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: ConsumedFoodItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultWithIncludesAsync(id.Value,User.GetUserId()!.Value);

            if (consumedFoodItem == null)
            {
                return NotFound();
            }

            return View(consumedFoodItem);
        }

        // GET: ConsumedFoodItems/Create
        public async Task<IActionResult> Create()
        {
            Console.WriteLine("1");
            var vm = new ConsumedFoodItemCreateEditViewModel();
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title));
            return View(vm);
        }

        // POST: ConsumedFoodItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsumedFoodItemCreateEditViewModel vm)
        {
            Console.WriteLine("2");
            Console.WriteLine(ModelState);
            Console.WriteLine(vm.ConsumedFoodItem.AppUserId);
            Console.WriteLine(User.GetUserId()!.Value);
            if (ModelState.IsValid)
            {
                Console.WriteLine("3");
                vm.ConsumedFoodItem.AppUserId = User.GetUserId()!.Value;
                Console.WriteLine(vm.ConsumedFoodItem.GetType());
                _bll.ConsumedFoodItems.Add(vm.ConsumedFoodItem);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y=>y.Count>0)
                    .ToList();
                Console.WriteLine(errors);
            }
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.ConsumedFoodItem.FoodItemId);
            return View(vm);
        }

        // GET: ConsumedFoodItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultWithIncludesAsync(id.Value,User.GetUserId()!.Value);
            if (consumedFoodItem == null)
            {
                return NotFound();
            }
            var vm = new ConsumedFoodItemCreateEditViewModel();
            vm.ConsumedFoodItem = consumedFoodItem;
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.ConsumedFoodItem.FoodItemId);
            return View(vm);
        }

        // POST: ConsumedFoodItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ConsumedFoodItemCreateEditViewModel vm)
        {
            if (id != vm.ConsumedFoodItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.ConsumedFoodItem.AppUserId = User.GetUserId()!.Value;
                    _bll.ConsumedFoodItems.Update(vm.ConsumedFoodItem);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ConsumedFoodItemExists(vm.ConsumedFoodItem.Id))
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
            vm.FoodItemSelectList = new SelectList(await _bll.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.ConsumedFoodItem.FoodItemId);
            return View(vm);
        }

        // GET: ConsumedFoodItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (consumedFoodItem == null)
            {
                return NotFound();
            }

            return View(consumedFoodItem);
        }

        // POST: ConsumedFoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consumedFoodItem = await _bll.ConsumedFoodItems.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (consumedFoodItem == null)
            {
                return NotFound();
            }
            _bll.ConsumedFoodItems.Remove(consumedFoodItem);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ConsumedFoodItemExists(Guid id)
        {
            return await _bll.ConsumedFoodItems.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
