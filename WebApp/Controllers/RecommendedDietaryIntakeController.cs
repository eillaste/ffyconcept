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
    public class RecommendedDietaryIntakeController : Controller
    {
        private readonly IAppBLL _bll;

        public RecommendedDietaryIntakeController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: RecommendedDietaryIntake
        public async Task<IActionResult> Index()
        {
            var res = await _bll.RecommendedDietaryIntake.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: RecommendedDietaryIntake/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedDietaryIntake = await _bll.RecommendedDietaryIntake.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (recommendedDietaryIntake == null)
            {
                return NotFound();
            }

            return View(recommendedDietaryIntake);
        }

        // GET: RecommendedDietaryIntake/Create
        public async Task<IActionResult> Create()
        {
            // RANGES
            var cheat = (await _bll.AgeGroups.GetAllAsync()).Select(x => new PublicApi.DTO.v1.AgeGroup()
            {
                Range = x.LowerBound + "-" + x.UpperBound
            }).ToList();
            
            var vm = new RecommendedDietaryIntakeCreateEditViewModel();
            vm.AgeGroupSelectList = new SelectList(await _bll.AgeGroups.GetAllAsync(User.GetUserId()!.Value), nameof(AgeGroup.Id),nameof(AgeGroup.UpperBound));
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title));
           

            foreach (var item in vm.AgeGroupSelectList.Select((value, index) => new { value, index }))
            {
                item.value.Text = cheat[item.index].Range;
            }
            return View(vm);
        }

        // POST: RecommendedDietaryIntake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecommendedDietaryIntakeCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.RecommendedDietaryIntake.Add(vm.RecommendedDietaryIntake);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AgeGroupSelectList = new SelectList(await _bll.AgeGroups.GetAllAsync(User.GetUserId()!.Value), nameof(AgeGroup.Id),nameof(AgeGroup.UpperBound), vm.RecommendedDietaryIntake.AgeGroupId);
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.RecommendedDietaryIntake.NutrientId);
            return View(vm);
        }

        // GET: RecommendedDietaryIntake/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // RANGES
            var cheat = (await _bll.AgeGroups.GetAllAsync()).Select(x => new PublicApi.DTO.v1.AgeGroup()
            {
                Range = x.LowerBound + "-" + x.UpperBound
            }).ToList();
            
            var recommendedDietaryIntake = await _bll.RecommendedDietaryIntake.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (recommendedDietaryIntake == null)
            {
                return NotFound();
            }
            var vm = new RecommendedDietaryIntakeCreateEditViewModel();
            vm.RecommendedDietaryIntake = recommendedDietaryIntake;
            vm.AgeGroupSelectList = new SelectList(await _bll.AgeGroups.GetAllAsync(User.GetUserId()!.Value), nameof(AgeGroup.Id),nameof(AgeGroup.UpperBound), vm.RecommendedDietaryIntake.AgeGroupId);
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.RecommendedDietaryIntake.NutrientId);
            
            foreach (var item in vm.AgeGroupSelectList.Select((value, index) => new { value, index }))
            {
                item.value.Text = cheat[item.index].Range;
            }
            
            return View(vm);
        }

        // POST: RecommendedDietaryIntake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  RecommendedDietaryIntakeCreateEditViewModel vm)
        {
            if (id != vm.RecommendedDietaryIntake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.RecommendedDietaryIntake.Update(vm.RecommendedDietaryIntake);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await RecommendedDietaryIntakeExists(vm.RecommendedDietaryIntake.Id))
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
            vm.AgeGroupSelectList = new SelectList(await _bll.AgeGroups.GetAllAsync(User.GetUserId()!.Value), nameof(AgeGroup.Id),nameof(AgeGroup.UpperBound), vm.RecommendedDietaryIntake.AgeGroupId);
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.RecommendedDietaryIntake.NutrientId);
            return View(vm);
        }

        // GET: RecommendedDietaryIntake/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedDietaryIntake = await _bll.RecommendedDietaryIntake.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (recommendedDietaryIntake == null)
            {
                return NotFound();
            }

            return View(recommendedDietaryIntake);
        }

        // POST: RecommendedDietaryIntake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var recommendedDietaryIntake = await _bll.RecommendedDietaryIntake.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (recommendedDietaryIntake == null)
            {
                return NotFound();
            }
            _bll.RecommendedDietaryIntake.Remove(recommendedDietaryIntake);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<bool> RecommendedDietaryIntakeExists(Guid id)
        {
            return await _bll.RecommendedDietaryIntake.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
