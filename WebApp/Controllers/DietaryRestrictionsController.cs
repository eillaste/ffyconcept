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
    public class DietaryRestrictionsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public DietaryRestrictionsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: DietaryRestrictions
        public async Task<IActionResult> Index()
        {
            var res = await _uow.DietaryRestrictions.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: DietaryRestrictions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietaryRestriction = await _uow.DietaryRestrictions.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (dietaryRestriction == null)
            {
                return NotFound();
            }

            return View(dietaryRestriction);
        }

        // GET: DietaryRestrictions/Create
        public async Task<IActionResult> Create()
        {
            var vm = new DietaryRestrictionCreateEditViewModel();
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title));
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title));
            return View(vm);
        }

        // POST: DietaryRestrictions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DietaryRestrictionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.DietaryRestrictions.Add(vm.DietaryRestriction);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title), vm.DietaryRestriction.DietId);
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.DietaryRestriction.FoodItemId);
            return View(vm);
        }

        // GET: DietaryRestrictions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietaryRestriction = await _uow.DietaryRestrictions.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (dietaryRestriction == null)
            {
                return NotFound();
            }
            var vm = new DietaryRestrictionCreateEditViewModel();
            vm.DietaryRestriction = dietaryRestriction;
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title), vm.DietaryRestriction.DietId);
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.DietaryRestriction.FoodItemId);
            return View(vm);
        }

        // POST: DietaryRestrictions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DietaryRestrictionCreateEditViewModel vm)
        {
            if (id != vm.DietaryRestriction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.DietaryRestrictions.Update(vm.DietaryRestriction);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await DietaryRestrictionExists(vm.DietaryRestriction.Id))
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
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title), vm.DietaryRestriction.DietId);
            vm.FoodItemSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.DietaryRestriction.FoodItemId);
            return View(vm);
        }

        // GET: DietaryRestrictions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietaryRestriction = await _uow.DietaryRestrictions.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (dietaryRestriction == null)
            {
                return NotFound();
            }

            return View(dietaryRestriction);
        }

        // POST: DietaryRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.DietaryRestrictions.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DietaryRestrictionExists(Guid id)
        {
            return await _uow.DietaryRestrictions.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
