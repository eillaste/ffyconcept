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
    public class DishInOrderController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public DishInOrderController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: DishInOrder
        public async Task<IActionResult> Index()
        {
            var res = await _uow.DishInOrder.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: DishInOrder/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInOrder = await _uow.DishInOrder.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (dishInOrder == null)
            {
                return NotFound();
            }

            return View(dishInOrder);
        }

        // GET: DishInOrder/Create
        public async Task<IActionResult> Create()
        {
            var vm = new DishInOrderCreateEditViewModel();
            vm.DishInMenuSelectList = new SelectList(await _uow.DishInMenu.GetAllAsync(User.GetUserId()!.Value), nameof(DishInMenu.Id),nameof(DishInMenu.Id));
            vm.OrderSelectList = new SelectList(await _uow.Orders.GetAllAsync(User.GetUserId()!.Value), nameof(Order.Id),nameof(Order.OrderTime));
            return View(vm);
        }

        // POST: DishInOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DishInOrderCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.DishInOrder.AppUserId = User.GetUserId()!.Value;
                _uow.DishInOrder.Add(vm.DishInOrder);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", dishInOrder.AppUserId);
            vm.DishInMenuSelectList = new SelectList(await _uow.DishInMenu.GetAllAsync(User.GetUserId()!.Value), nameof(DishInMenu.Id),nameof(DishInMenu.Id), vm.DishInOrder.DishInMenuId);
            vm.OrderSelectList = new SelectList(await _uow.Orders.GetAllAsync(User.GetUserId()!.Value), nameof(Order.Id),nameof(Order.OrderTime), vm.DishInOrder.OrderId);
            return View(vm);
        }

        // GET: DishInOrder/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInOrder = await _uow.DishInOrder.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (dishInOrder == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", dishInOrder.AppUserId);
            var vm = new DishInOrderCreateEditViewModel();
            vm.DishInOrder = dishInOrder;
            vm.DishInMenuSelectList = new SelectList(await _uow.DishInMenu.GetAllAsync(User.GetUserId()!.Value), nameof(DishInMenu.Id),nameof(DishInMenu.Id), vm.DishInOrder.DishInMenuId);
            vm.OrderSelectList = new SelectList(await _uow.Orders.GetAllAsync(User.GetUserId()!.Value), nameof(Order.Id),nameof(Order.OrderTime), vm.DishInOrder.OrderId);
            return View(vm);
        }

        // POST: DishInOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DishInOrderCreateEditViewModel vm)
        {
            if (id != vm.DishInOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.DishInOrder.AppUserId = User.GetUserId()!.Value;
                    _uow.DishInOrder.Update(vm.DishInOrder);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await DishInOrderExists(vm.DishInOrder.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", dishInOrder.AppUserId);
            vm.DishInMenuSelectList = new SelectList(await _uow.DishInMenu.GetAllAsync(User.GetUserId()!.Value), nameof(DishInMenu.Id),nameof(DishInMenu.Id), vm.DishInOrder.DishInMenuId);
            vm.OrderSelectList = new SelectList(await _uow.Orders.GetAllAsync(User.GetUserId()!.Value), nameof(Order.Id),nameof(Order.OrderTime), vm.DishInOrder.OrderId);
            return View(vm);
        }

        // GET: DishInOrder/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInOrder = await _uow.DishInOrder.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (dishInOrder == null)
            {
                return NotFound();
            }

            return View(dishInOrder);
        }

        // POST: DishInOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.DishInOrder.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DishInOrderExists(Guid id)
        {
            return await _uow.DishInOrder.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
