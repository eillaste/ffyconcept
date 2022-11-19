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
    public class PersonSupplementsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PersonSupplementsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PersonSupplements
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PersonSupplements.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PersonSupplements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personSupplement = await _uow.PersonSupplements.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personSupplement == null)
            {
                return NotFound();
            }

            return View(personSupplement);
        }

        // GET: PersonSupplements/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PersonSupplementCreateEditViewModel();
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title));
            return View(vm);
        }

        // POST: PersonSupplements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PersonSupplementCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PersonSupplement.AppUserId = User.GetUserId()!.Value;
                _uow.PersonSupplements.Add(vm.PersonSupplement);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title), vm.PersonSupplement.SupplementId);
            return View(vm);
        }

        // GET: PersonSupplements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personSupplement = await _uow.PersonSupplements.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personSupplement == null)
            {
                return NotFound();
            }
            var vm = new PersonSupplementCreateEditViewModel();
            vm.PersonSupplement = personSupplement;
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title), vm.PersonSupplement.SupplementId);
            return View(vm);
        }

        // POST: PersonSupplements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,PersonSupplementCreateEditViewModel vm)
        {
            if (id != vm.PersonSupplement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.PersonSupplement.AppUserId = User.GetUserId()!.Value;
                    _uow.PersonSupplements.Update(vm.PersonSupplement);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await PersonSupplementExists(vm.PersonSupplement.Id))
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
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title), vm.PersonSupplement.SupplementId);
            return View(vm);
        }

        // GET: PersonSupplements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personSupplement = await _uow.PersonSupplements.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personSupplement == null)
            {
                return NotFound();
            }

            return View(personSupplement);
        }

        // POST: PersonSupplements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PersonSupplements.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonSupplementExists(Guid id)
        {
            return await _uow.PersonSupplements.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
