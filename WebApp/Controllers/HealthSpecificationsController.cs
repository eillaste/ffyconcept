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
    public class HealthSpecificationsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public HealthSpecificationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: HealthSpecifications
        public async Task<IActionResult> Index()
        {
            var res = await _uow.HealthSpecifications.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: HealthSpecifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthSpecification = await _uow.HealthSpecifications.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (healthSpecification == null)
            {
                return NotFound();
            }

            return View(healthSpecification);
        }

        // GET: HealthSpecifications/Create
        public IActionResult Create()
        {
            var vm = new HealthSpecificationCreateEditViewModel();
            return View(vm);
        }

        // POST: HealthSpecifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HealthSpecificationCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.HealthSpecifications.Add(vm.HealthSpecification);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: HealthSpecifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthSpecification = await _uow.HealthSpecifications.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (healthSpecification == null)
            {
                return NotFound();
            }
            var vm = new HealthSpecificationCreateEditViewModel();
            vm.HealthSpecification = healthSpecification;
            return View(vm);
        }

        // POST: HealthSpecifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, HealthSpecificationCreateEditViewModel vm)
        {
            if (id != vm.HealthSpecification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.HealthSpecifications.Update(vm.HealthSpecification);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await HealthSpecificationExists(vm.HealthSpecification.Id))
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
            return View(vm);
        }

        // GET: HealthSpecifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthSpecification = await _uow.HealthSpecifications.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (healthSpecification == null)
            {
                return NotFound();
            }

            return View(healthSpecification);
        }

        // POST: HealthSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.HealthSpecifications.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> HealthSpecificationExists(Guid id)
        {
            return await _uow.HealthSpecifications.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
