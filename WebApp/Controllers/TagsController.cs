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
    [Authorize(Roles = "customer,company,admin" )]
    public class TagsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public TagsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Tags.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _uow.Tags.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            Console.Write(tag!.Id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            var vm = new TagCreateEditViewModel();
            return View(vm);
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Tag.AppUserId = User.GetUserId()!.Value;
                _uow.Tags.Add(vm.Tag);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", tag.AppUserId);
            return View(vm);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _uow.Tags.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            
            if (tag == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", tag.AppUserId);
            var vm = new TagCreateEditViewModel();
            vm.Tag = tag;
            return View(vm);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TagCreateEditViewModel vm)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            if (id != vm.Tag.Id)
            {
                Console.WriteLine(id);
                Console.WriteLine(vm.Tag.Id);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    vm.Tag.AppUserId = User.GetUserId()!.Value;
                    _uow.Tags.Update(vm.Tag);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await TagExists(vm.Tag.Id))
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
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", tag.AppUserId);
            return View(vm);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _uow.Tags.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Tags.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TagExists(Guid id)
        {
            return await _uow.Tags.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
