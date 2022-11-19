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
    public class TolerableUpperIntakeLevelsController : Controller
    {
        private readonly IAppBLL _bll;

        public TolerableUpperIntakeLevelsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: TolerableUpperIntakeLevels
        public async Task<IActionResult> Index()
        {
            var res = await _bll.TolerableUpperIntakeLevels.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: TolerableUpperIntakeLevels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tolerableUpperIntakeLevel = await _bll.TolerableUpperIntakeLevels.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (tolerableUpperIntakeLevel == null)
            {
                return NotFound();
            }

            return View(tolerableUpperIntakeLevel);
        }

        // GET: TolerableUpperIntakeLevels/Create
        public async Task<IActionResult> Create()
        {
            var vm = new TolerableUpperIntakeLevelCreateEditViewModel();
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title));
            //ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            return View(vm);
        }

        // POST: TolerableUpperIntakeLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TolerableUpperIntakeLevelCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.TolerableUpperIntakeLevels.Add(vm.TolerableUpperIntakeLevel);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.TolerableUpperIntakeLevel.NutrientId);
            return View(vm);
        }

        // GET: TolerableUpperIntakeLevels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tolerableUpperIntakeLevel = await _bll.TolerableUpperIntakeLevels.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (tolerableUpperIntakeLevel == null)
            {
                return NotFound();
            }
            //ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            var vm = new TolerableUpperIntakeLevelCreateEditViewModel();
            vm.TolerableUpperIntakeLevel = tolerableUpperIntakeLevel;
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.TolerableUpperIntakeLevel.NutrientId);
            return View(vm);
            //return View(tolerableUpperIntakeLevel);
        }

        // POST: TolerableUpperIntakeLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TolerableUpperIntakeLevelCreateEditViewModel vm)
        {
            if (id != vm.TolerableUpperIntakeLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.TolerableUpperIntakeLevels.Update(vm.TolerableUpperIntakeLevel);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await TolerableUpperIntakeLevelExists(vm.TolerableUpperIntakeLevel.Id))
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
            //ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.TolerableUpperIntakeLevel.NutrientId);
            return View(vm);
        }

        // GET: TolerableUpperIntakeLevels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tolerableUpperIntakeLevel = await _bll.TolerableUpperIntakeLevels.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (tolerableUpperIntakeLevel == null)
            {
                return NotFound();
            }

            return View(tolerableUpperIntakeLevel);
        }

        // POST: TolerableUpperIntakeLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tolerableUpperIntakeLevel = await _bll.TolerableUpperIntakeLevels.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (tolerableUpperIntakeLevel == null)
            {
                return NotFound();
            }
            _bll.TolerableUpperIntakeLevels.Remove(tolerableUpperIntakeLevel);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<bool> TolerableUpperIntakeLevelExists(Guid id)
        {
            return await _bll.TolerableUpperIntakeLevels.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
