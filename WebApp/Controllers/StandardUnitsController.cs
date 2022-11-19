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
    public class StandardUnitsController : Controller
    {
        //private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;

        public StandardUnitsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: StandardUnits
        public async Task<IActionResult> Index()
        {
            var res = await _bll.StandardUnits.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: StandardUnits/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (standardUnit == null)
            {
                return NotFound();
            }

            return View(standardUnit);
        }

        // GET: StandardUnits/Create
        public IActionResult Create()
        {
            var vm = new StandardUnitCreateEditViewModel();
            return View(vm);
        }

        // POST: StandardUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StandardUnitCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.StandardUnits.Add(vm.StandardUnit);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: StandardUnits/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (standardUnit == null)
            {
                return NotFound();
            }
            var vm = new StandardUnitCreateEditViewModel();
            vm.StandardUnit = standardUnit;
            return View(vm);
        }

        // POST: StandardUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StandardUnitCreateEditViewModel vm)
        {
            if (id != vm.StandardUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.StandardUnits.Update(vm.StandardUnit);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await StandardUnitExists(vm.StandardUnit.Id))
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

        // GET: StandardUnits/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (standardUnit == null)
            {
                return NotFound();
            }

            return View(standardUnit);
        }

        // POST: StandardUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            /*await _uow.StandardUnits.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            
            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (standardUnit == null)
            {
                return NotFound();
            }
            _bll.StandardUnits.Remove(standardUnit);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private  async Task<bool> StandardUnitExists(Guid id)
        {
            return await _bll.StandardUnits.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
