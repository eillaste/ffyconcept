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
    public class DietsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public DietsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Diets
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Diets.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Diets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _uow.Diets.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // GET: Diets/Create
        public IActionResult Create()
        {
            var vm = new DietCreateEditViewModel();
            return View(vm);
        }

        // POST: Diets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DietCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Diets.Add(vm.Diet);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Diets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var diet = await _uow.Diets.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (diet == null)
            {
                return NotFound();
            }

            var vm = new DietCreateEditViewModel();
            vm.Diet = diet;
            return View(vm);
        }

        // POST: Diets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DietCreateEditViewModel vm)
        {
            if (id != vm.Diet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Diets.Update(vm.Diet);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await DietExists(vm.Diet.Id))
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

        // GET: Diets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _uow.Diets.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // POST: Diets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Diets.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DietExists(Guid id)
        {
            return await _uow.Diets.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
