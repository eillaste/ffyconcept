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
    public class PersonDietsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PersonDietsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PersonDiets
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PersonDiets.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PersonDiets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personDiet = await _uow.PersonDiets.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personDiet == null)
            {
                return NotFound();
            }

            return View(personDiet);
        }

        // GET: PersonDiets/Create
        public async Task<IActionResult> Create()
        {

            var vm = new PersonDietCreateEditViewModel();
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title));
            return View(vm);
        }

        // POST: PersonDiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonDietCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PersonDiet.AppUserId = User.GetUserId()!.Value;
                _uow.PersonDiets.Add(vm.PersonDiet);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", personDiet.AppUserId);
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title), vm.PersonDiet.DietId);
            return View(vm);
        }

        // GET: PersonDiets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personDiet = await _uow.PersonDiets.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personDiet == null)
            {
                return NotFound();
            }
            var vm = new PersonDietCreateEditViewModel();
            vm.PersonDiet = personDiet;
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title), vm.PersonDiet.DietId);
            return View(vm);
        }

        // POST: PersonDiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PersonDietCreateEditViewModel vm)
        {
            if (id != vm.PersonDiet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.PersonDiet.AppUserId = User.GetUserId()!.Value;
                    _uow.PersonDiets.Update(vm.PersonDiet);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await PersonDietExists(vm.PersonDiet.Id))
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
            vm.DietSelectList = new SelectList(await _uow.Diets.GetAllAsync(User.GetUserId()!.Value), nameof(Diet.Id),nameof(Diet.Title), vm.PersonDiet.DietId);
            return View(vm);
        }

        // GET: PersonDiets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personDiet = await _uow.PersonDiets.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personDiet == null)
            {
                return NotFound();
            }

            return View(personDiet);
        }

        // POST: PersonDiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PersonDiets.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonDietExists(Guid id)
        {
            return await _uow.PersonDiets.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
