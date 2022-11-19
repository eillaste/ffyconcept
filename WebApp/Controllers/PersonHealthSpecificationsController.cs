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
    public class PersonHealthSpecificationsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PersonHealthSpecificationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PersonHealthSpecifications
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PersonHealthSpecifications.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PersonHealthSpecifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personHealthSpecification = await _uow.PersonHealthSpecifications.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personHealthSpecification == null)
            {
                return NotFound();
            }

            return View(personHealthSpecification);
        }

        // GET: PersonHealthSpecifications/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PersonHealthSpecificationCreateEditViewModel();
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title));
            return View(vm);
        }

        // POST: PersonHealthSpecifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonHealthSpecificationCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.PersonHealthSpecification.AppUserId = User.GetUserId()!.Value;
                _uow.PersonHealthSpecifications.Add(vm.PersonHealthSpecification);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title), vm.PersonHealthSpecification.HealthSpecificationId);
            return View(vm);
        }

        // GET: PersonHealthSpecifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personHealthSpecification = await _uow.PersonHealthSpecifications.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personHealthSpecification == null)
            {
                return NotFound();
            }
            var vm = new PersonHealthSpecificationCreateEditViewModel();
            vm.PersonHealthSpecification = personHealthSpecification;
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title), vm.PersonHealthSpecification.HealthSpecificationId);
            return View(vm);
        }

        // POST: PersonHealthSpecifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,PersonHealthSpecificationCreateEditViewModel vm)
        {
            if (id != vm.PersonHealthSpecification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.PersonHealthSpecification.AppUserId = User.GetUserId()!.Value;
                    _uow.PersonHealthSpecifications.Update(vm.PersonHealthSpecification);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await PersonHealthSpecificationExists(vm.PersonHealthSpecification.Id))
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
            vm.HealthSpecificationSelectList = new SelectList(await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value), nameof(HealthSpecification.Id),nameof(HealthSpecification.Title), vm.PersonHealthSpecification.HealthSpecificationId);
            return View(vm);
        }

        // GET: PersonHealthSpecifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personHealthSpecification = await _uow.PersonHealthSpecifications.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personHealthSpecification == null)
            {
                return NotFound();
            }

            return View(personHealthSpecification);
        }

        // POST: PersonHealthSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PersonHealthSpecifications.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonHealthSpecificationExists(Guid id)
        {
            return await _uow.PersonHealthSpecifications.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
