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
    public class PersonAllergensController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PersonAllergensController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PersonAllergens
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PersonAllergens.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PersonAllergens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAllergen = await _uow.PersonAllergens.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personAllergen == null)
            {
                return NotFound();
            }

            return View(personAllergen);
        }

        // GET: PersonAllergens/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PersonAllergenCreateEditViewModel();
            vm.AllergenSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title));
            return View(vm);
        }

        // POST: PersonAllergens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonAllergenCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PersonAllergen.AppUserId = User.GetUserId()!.Value;
                _uow.PersonAllergens.Add(vm.PersonAllergen);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AllergenSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.PersonAllergen.FoodItemId);
            return View(vm);
        }

        // GET: PersonAllergens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAllergen = await _uow.PersonAllergens.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personAllergen == null)
            {
                return NotFound();
            }
            var vm = new PersonAllergenCreateEditViewModel();
            vm.PersonAllergen = personAllergen;
            vm.AllergenSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.PersonAllergen.FoodItemId);
            return View(vm);
        }

        // POST: PersonAllergens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PersonAllergenCreateEditViewModel vm)
        {
            if (id != vm.PersonAllergen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.PersonAllergen.AppUserId = User.GetUserId()!.Value;
                    _uow.PersonAllergens.Update(vm.PersonAllergen);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await PersonAllergenExists(vm.PersonAllergen.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", personAllergen.AppUserId);
            vm.AllergenSelectList = new SelectList(await _uow.FoodItems.GetAllAsync(User.GetUserId()!.Value), nameof(FoodItem.Id),nameof(FoodItem.Title), vm.PersonAllergen.FoodItemId);
            return View(vm);
        }

        // GET: PersonAllergens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAllergen = await _uow.PersonAllergens.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personAllergen == null)
            {
                return NotFound();
            }

            return View(personAllergen);
        }

        // POST: PersonAllergens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PersonAllergens.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonAllergenExists(Guid id)
        {
            return await _uow.PersonAllergens.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
