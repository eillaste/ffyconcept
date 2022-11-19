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
    public class CategoriesController : Controller
    {
        private readonly IAppBLL _bll;

        public CategoriesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var res = await _bll.Categories.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _bll.Categories.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            var vm = new CategoryCreateEditViewModel();
            return View(vm);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Categories.Add(vm.Category);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _bll.Categories.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (category == null)
            {
                return NotFound();
            }

            var vm = new CategoryCreateEditViewModel();
            vm.Category = category;
            return View(vm);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoryCreateEditViewModel vm)
        {
            if (id != vm.Category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Categories.Update(vm.Category);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await CategoryExists(vm.Category.Id))
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

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _bll.Categories.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (category == null)
            {
                return NotFound();
            }
            _bll.Categories.Remove(category);
            await _bll.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoryExists(Guid id)
        {
            return await _bll.Categories.ExistsAsync(id,User.GetUserId()!.Value);

        }
    }
}
