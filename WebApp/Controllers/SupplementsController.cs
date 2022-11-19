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
    public class SupplementsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SupplementsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Supplements
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Supplements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplement = await _uow.Supplements.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (supplement == null)
            {
                return NotFound();
            }
            Console.WriteLine(supplement.StandardUnitId);
            return View(supplement);
        }

        // GET: Supplements/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SupplementCreateEditViewModel();
            vm.StandardUnitSelectList = new SelectList(await _uow.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title));
            return View(vm);
        }

        // POST: Supplements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplementCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Supplements.Add(vm.Supplement);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.StandardUnitSelectList = new SelectList(await _uow.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.Supplement.StandardUnitId);
            return View(vm);
        }

        // GET: Supplements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplement = await _uow.Supplements.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (supplement == null)
            {
                return NotFound();
            }
            var vm = new SupplementCreateEditViewModel();
            vm.Supplement = supplement;
            vm.StandardUnitSelectList = new SelectList(await _uow.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.Supplement.StandardUnitId);
            return View(vm);
        }

        // POST: Supplements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplementCreateEditViewModel vm)
        {
            if (id != vm.Supplement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Supplements.Update(vm.Supplement);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await SupplementExists(vm.Supplement.Id))
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
            vm.StandardUnitSelectList = new SelectList(await _uow.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.Supplement.StandardUnitId);
            return View(vm);
        }

        // GET: Supplements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplement = await _uow.Supplements.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (supplement == null)
            {
                return NotFound();
            }

            return View(supplement);
        }

        // POST: Supplements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Supplements.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SupplementExists(Guid id)
        {
            return await _uow.Supplements.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
