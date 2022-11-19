using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
    [Authorize(Roles = "admin")]
    public class AgeGroupsController : Controller
    {
        //private readonly AppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        public AgeGroupsController(IAppBLL bll)
        {
            //_uow = uow;
            _bll = bll;
        }

        // GET: AgeGroups
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("customer"))
            {
                var res = await _bll.AgeGroups.GetAllAsync(User.GetUserId()!.Value);
                await _bll.SaveChangesAsync();
                return View(res); 
            }
            else
            {
                            var res = await _bll.AgeGroups.GetAllAsync();
                            await _bll.SaveChangesAsync();
                            return View(res);
            }

        }

        // GET: AgeGroups/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ageGroup = await _bll.AgeGroups.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (ageGroup == null)
            {
                return NotFound();
            }

            return View(ageGroup);
        }

        // GET: AgeGroups/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var vm = new AgeGroupCreateEditViewModel();
            return View(vm);
        }

        // POST: AgeGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(AgeGroupCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.AgeGroups.Add(vm.AgeGroup);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: AgeGroups/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ageGroup = await _bll.AgeGroups.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (ageGroup == null)
            {
                return NotFound();
            }
            var vm = new AgeGroupCreateEditViewModel();
            vm.AgeGroup = ageGroup;
            return View(vm);
        }

        // POST: AgeGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Guid id, AgeGroupCreateEditViewModel vm)
        {
            if (id != vm.AgeGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.AgeGroups.Update(vm.AgeGroup);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await AgeGroupExists(vm.AgeGroup.Id))
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

        // GET: AgeGroups/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ageGroup = await _bll.AgeGroups.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (ageGroup == null)
            {
                return NotFound();
            }
            Console.WriteLine("doesn't crash in delete get");
            return View(ageGroup);
        }

        // POST: AgeGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ageGroup = await _bll.AgeGroups.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (ageGroup == null)
            {
                return NotFound();
            }
            _bll.AgeGroups.Remove(ageGroup);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        //[Authorize(Roles = "admin")]
        private async Task<bool> AgeGroupExists(Guid id)
        {
            Console.WriteLine("AM I EVER IN HER?E");
            return await _bll.AgeGroups.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
