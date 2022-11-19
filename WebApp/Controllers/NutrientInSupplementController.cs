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
    public class NutrientInSupplementController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public NutrientInSupplementController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: NutrientInSupplement
        public async Task<IActionResult> Index()
        {
            var res = await _uow.NutrientInSupplement.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: NutrientInSupplement/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrientInSupplement = await _uow.NutrientInSupplement.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrientInSupplement == null)
            {
                return NotFound();
            }

            return View(nutrientInSupplement);
        }

        // GET: NutrientInSupplement/Create
        public async Task<IActionResult> Create()
        {
            var vm = new NutrientInSupplementCreateEditViewModel();
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title));
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title));
            return View(vm);
        }

        // POST: NutrientInSupplement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NutrientInSupplementCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.NutrientInSupplement.Add(vm.NutrientInSupplement);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.NutrientInSupplement.NutrientId);
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title), vm.NutrientInSupplement.SupplementId);
            return View(vm);
        }

        // GET: NutrientInSupplement/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrientInSupplement = await _uow.NutrientInSupplement.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrientInSupplement == null)
            {
                return NotFound();
            }
            var vm = new NutrientInSupplementCreateEditViewModel();
            vm.NutrientInSupplement = nutrientInSupplement;
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.NutrientInSupplement.NutrientId);
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title), vm.NutrientInSupplement.SupplementId);
            return View(vm);
        }

        // POST: NutrientInSupplement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, NutrientInSupplementCreateEditViewModel vm)
        {
            if (id != vm.NutrientInSupplement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.NutrientInSupplement.Update(vm.NutrientInSupplement);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await NutrientInSupplementExists(vm.NutrientInSupplement.Id))
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
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.NutrientInSupplement.NutrientId);
            vm.SupplementSelectList = new SelectList(await _uow.Supplements.GetAllAsync(User.GetUserId()!.Value), nameof(Supplement.Id),nameof(Supplement.Title), vm.NutrientInSupplement.SupplementId);
            return View(vm);
        }

        // GET: NutrientInSupplement/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrientInSupplement = await _uow.NutrientInSupplement.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrientInSupplement == null)
            {
                return NotFound();
            }

            return View(nutrientInSupplement);
        }

        // POST: NutrientInSupplement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.NutrientInSupplement.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> NutrientInSupplementExists(Guid id)
        {
            return await _uow.NutrientInSupplement.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
