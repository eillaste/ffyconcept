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
    public class NutrientsController : Controller
    {
        private readonly IAppBLL _bll;

        public NutrientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Nutrients
        public async Task<IActionResult> Index()
        {
            var res = await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Nutrients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrient = await _bll.Nutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrient == null)
            {
                return NotFound();
            }

            return View(nutrient);
        }

        // GET: Nutrients/Create
        public async Task<IActionResult> Create()
        {
            var vm = new NutrientCreateEditViewModel();
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title));
            return View(vm);
        }

        // POST: Nutrients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NutrientCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Nutrients.Add(vm.Nutrient);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StandardUnitId"] = new SelectList(await _uow.StandardUnits.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.Nutrient.StandardUnitId);
            return View(vm);
        }

        // GET: Nutrients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrient = await _bll.Nutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (nutrient == null)
            {
                return NotFound();
            }
            var vm = new NutrientCreateEditViewModel();
            vm.Nutrient = nutrient;
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.Nutrient.StandardUnitId);
            return View(vm);
        }

        // POST: Nutrients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, NutrientCreateEditViewModel vm)
        {
            if (id != vm.Nutrient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Nutrients.Update(vm.Nutrient);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await NutrientExists(vm.Nutrient.Id))
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
            vm.StandardUnitSelectList = new SelectList(await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value), nameof(StandardUnit.Id),nameof(StandardUnit.Title), vm.Nutrient.StandardUnitId);
            return View(vm);
        }

        // GET: Nutrients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrient = await _bll.Nutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (nutrient == null)
            {
                return NotFound();
            }

            return View(nutrient);
        }

        // POST: Nutrients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.Nutrients.RemoveAsync(id,User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> NutrientExists(Guid id)
        {
            return await _bll.Nutrients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
