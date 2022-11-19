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
using ConsumedNutrient = DAL.App.DTO.ConsumedNutrient;

namespace WebApp.Controllers
{
    [Authorize(Roles = "customer,admin" )]
    public class ConsumedNutrientsController : Controller
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        public ConsumedNutrientsController(IAppUnitOfWork uow, IAppBLL bll)
        {
            _uow = uow;
            _bll = bll;
        }

        // GET: ConsumedNutrients
        public async Task<IActionResult> Index()
        {
            var res = await _bll.ConsumedNutrients.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: ConsumedNutrients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedNutrient = await _bll.ConsumedNutrients.FirstOrDefaultWithIncludesAsync(id.Value,User.GetUserId()!.Value);
            if (consumedNutrient == null)
            {
                return NotFound();
            }

            return View(consumedNutrient);
        }

        // GET: ConsumedNutrients/Create
        public async Task<IActionResult> Create()
        {
            Console.WriteLine("1");
            var vm = new ConsumedNutrientCreateEditViewModel();
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title));
            return View(vm);
        }

        // POST: ConsumedNutrients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsumedNutrientCreateEditViewModel vm)
        {
            Console.WriteLine("2");
            Console.WriteLine(ModelState);
            Console.WriteLine(vm.ConsumedNutrient.AppUserId);
            Console.WriteLine(User.GetUserId()!.Value);
            if (ModelState.IsValid)
            {
                Console.WriteLine("3");
                vm.ConsumedNutrient.AppUserId = User.GetUserId()!.Value;
                Console.WriteLine(vm.ConsumedNutrient.GetType());
                _bll.ConsumedNutrients.Add(vm.ConsumedNutrient);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y=>y.Count>0)
                    .ToList();
                Console.WriteLine(errors);
            }*/
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.ConsumedNutrient.NutrientId);
            return View(vm);
        }

        // GET: ConsumedNutrients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedNutrient = await _bll.ConsumedNutrients.FirstOrDefaultWithIncludesAsync(id.Value,User.GetUserId()!.Value);
            if (consumedNutrient == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", consumedNutrient.AppUserId);
            var vm = new ConsumedNutrientCreateEditViewModel();
            vm.ConsumedNutrient = consumedNutrient;
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.ConsumedNutrient.NutrientId);
            return View(vm);
        }

        // POST: ConsumedNutrients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,ConsumedNutrientCreateEditViewModel vm)
        {
            if (id != vm.ConsumedNutrient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.ConsumedNutrient.AppUserId = User.GetUserId()!.Value;
                    _bll.ConsumedNutrients.Update(vm.ConsumedNutrient);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ConsumedNutrientExists(vm.ConsumedNutrient.Id))
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
            vm.NutrientSelectList = new SelectList(await _bll.Nutrients.GetAllAsync(User.GetUserId()!.Value), nameof(Nutrient.Id),nameof(Nutrient.Title), vm.ConsumedNutrient.NutrientId);
            return View(vm);
        }

        // GET: ConsumedNutrients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedNutrient = await _bll.ConsumedNutrients.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (consumedNutrient == null)
            {
                return NotFound();
            }
            

            return View(consumedNutrient);
        }

        // POST: ConsumedNutrients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consumedNutrient = await _bll.ConsumedNutrients.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (consumedNutrient == null)
            {
                return NotFound();
            }
            _bll.ConsumedNutrients.Remove(consumedNutrient);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ConsumedNutrientExists(Guid id)
        {
            return await _bll.ConsumedNutrients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
