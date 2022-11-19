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
    public class HealthSpecificationNutrientsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public HealthSpecificationNutrientsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: HealthSpecificationNutrients
        public async Task<IActionResult> Index()
        {
            var res = await _uow.HealthSpecificationNutrients.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: HealthSpecificationNutrients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthSpecificationNutrient = await _uow.HealthSpecificationNutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (healthSpecificationNutrient == null)
            {
                return NotFound();
            }

            return View(healthSpecificationNutrient);
        }

        // GET: HealthSpecificationNutrients/Create
        public async Task<IActionResult> Create()
        {
            var vm = new HealthSpecificationNutrientCreateEditViewModel();
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title));
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title));
            return View(vm);
        }

        // POST: HealthSpecificationNutrients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HealthSpecificationNutrientCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.HealthSpecificationNutrients.Add(vm.HealthSpecificationNutrient);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title), vm.HealthSpecificationNutrient.HealthSpecificationId);
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.HealthSpecificationNutrient.NutrientId);
            return View(vm);
        }

        // GET: HealthSpecificationNutrients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthSpecificationNutrient = await _uow.HealthSpecificationNutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (healthSpecificationNutrient == null)
            {
                return NotFound();
            }
            var vm = new HealthSpecificationNutrientCreateEditViewModel();
            vm.HealthSpecificationNutrient = healthSpecificationNutrient;
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title), vm.HealthSpecificationNutrient.HealthSpecificationId);
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.HealthSpecificationNutrient.NutrientId);
            return View(vm);
        }

        // POST: HealthSpecificationNutrients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, HealthSpecificationNutrientCreateEditViewModel vm)
        {
            if (id != vm.HealthSpecificationNutrient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.HealthSpecificationNutrients.Update(vm.HealthSpecificationNutrient);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await HealthSpecificationNutrientExists(vm.HealthSpecificationNutrient.Id))
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
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title), vm.HealthSpecificationNutrient.HealthSpecificationId);
            vm.NutrientSelectList = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.HealthSpecificationNutrient.NutrientId);
            return View(vm);
        }

        // GET: HealthSpecificationNutrients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthSpecificationNutrient = await _uow.HealthSpecificationNutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (healthSpecificationNutrient == null)
            {
                return NotFound();
            }

            return View(healthSpecificationNutrient);
        }

        // POST: HealthSpecificationNutrients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.HealthSpecificationNutrients.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> HealthSpecificationNutrientExists(Guid id)
        {
            return await _uow.HealthSpecificationNutrients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
