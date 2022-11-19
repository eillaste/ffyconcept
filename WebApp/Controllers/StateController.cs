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
    [Authorize(Roles = "admin" )]
    public class StateController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public StateController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: State
        public async Task<IActionResult> Index()
        {
            var res = await _uow.State.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: State/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _uow.State.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: State/Create
        public IActionResult Create()
        {
            var vm = new StateCreateEditViewModel();
            return View(vm);
        }

        // POST: State/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StateCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.State.Add(vm.State);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: State/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _uow.State.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (state == null)
            {
                return NotFound();
            }
            var vm = new StateCreateEditViewModel();
            vm.State = state;
            return View(vm);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StateCreateEditViewModel vm)
        {
            if (id != vm.State.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.State.Update(vm.State);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await StateExists(vm.State.Id))
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
            return View(vm);
        }

        // GET: State/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _uow.State.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.State.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StateExists(Guid id)
        {
            return await _uow.State.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
