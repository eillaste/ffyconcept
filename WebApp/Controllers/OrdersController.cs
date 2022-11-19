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
using Order = DAL.App.DTO.Order;

namespace WebApp.Controllers
{
    [Authorize(Roles = "customer,company,admin" )]
    public class OrdersController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public OrdersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Orders.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _uow.Orders.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            ViewData["InvoiceId"] = new SelectList(await _uow.Invoices.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RestaurantId"] = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), "Id", "Description");
            ViewData["StateId"] = new SelectList(await _uow.State.GetAllAsync(User.GetUserId()!.Value), "Id", "StateTitle");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DAL.App.DTO.Order order)
        {
            if (ModelState.IsValid)
            {
                _uow.Orders.Add(order);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", order.AppUserId);
           ViewData["InvoiceId"] = new SelectList(await _uow.Invoices.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
           ViewData["RestaurantId"] = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), "Id", "Description");
           ViewData["StateId"] = new SelectList(await _uow.State.GetAllAsync(User.GetUserId()!.Value), "Id", "StateTitle");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _uow.Orders.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (order == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", order.AppUserId);
            ViewData["InvoiceId"] = new SelectList(await _uow.Invoices.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RestaurantId"] = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), "Id", "Description");
            ViewData["StateId"] = new SelectList(await _uow.State.GetAllAsync(User.GetUserId()!.Value), "Id", "StateTitle");
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Orders.Update(order);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await OrderExists(order.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", order.AppUserId);
            ViewData["InvoiceId"] = new SelectList(await _uow.Invoices.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RestaurantId"] = new SelectList(await _uow.Restaurants.GetAllAsync(User.GetUserId()!.Value), "Id", "Description");
            ViewData["StateId"] = new SelectList(await _uow.State.GetAllAsync(User.GetUserId()!.Value), "Id", "StateTitle");
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _uow.Orders.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Orders.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderExists(Guid id)
        {
            return await _uow.Orders.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
